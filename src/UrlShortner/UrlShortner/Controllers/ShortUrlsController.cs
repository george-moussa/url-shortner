using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using UrlShortner.Models;

namespace UrlShortner.Controllers;

[Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},BasicAuthentication")]
[ApiController]
[Route("[controller]")]
public class ShortUrlsController : ControllerBase
{
    private readonly UrlShortenerContext _context;
    public ShortUrlsController(UrlShortenerContext context)
    {
        _context = context;
    }
    
    [HttpPut("{id}")]
    public string CreateShortUrl(string id, [FromBody] JsonElement body)
    {
        var domainName = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";

        Console.WriteLine($"request to create: {id}, {body.GetProperty("url")}");
        Url url = new()
        {
            OriginalUrl = body.GetProperty("url").ToString(),
            ShortenedUrl = $"{domainName}/navigate/{Guid.NewGuid()}",
            UrlId = id,
            UserId = 0
        };

        _context.Urls.Add(url);
        _context.SaveChanges();

        return url.ShortenedUrl;
    }

    [HttpDelete("{id}")]
    public string DeleteShortUrl(string id)
    {
        Console.WriteLine($"request to delete: {id}");

        var url = _context.Urls.FirstOrDefault(u => string.Equals(u.UrlId, id));
        if (url != null)
        {
            _context.Remove(url);
            _context.SaveChanges();
            return "deleted!";
        }

        return "not found!";
    }

    [HttpGet("{id}")]
    public Url GetShortUrl(string id)
    {
        var url = _context.Urls.SingleOrDefault(u => u.UrlId == id);

        if (url == null)
        {
            return null;
        }

        return url;
    }

    [HttpGet]
    public List<Url> List()
    {
        return _context.Urls.ToList();
    }
}
