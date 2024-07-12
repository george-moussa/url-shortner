using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;

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
    [Authorize(Policy = "AddCustomer")]
    [HttpPut("{id}")]
    public string CreateShortUrl(string id, [FromBody] JsonElement body)
    {
        Console.WriteLine($"request to create: {id}, {body.GetProperty("url")}");
        return "https://shortUrl.com";
    }

    [Authorize(Roles = "Emperor,Deacon")]
    [HttpDelete("{id}")]
    public string DeleteShortUrl(string id)
    {
        Console.WriteLine($"request to delete: {id}");
        return "deleted!";
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public string GetShortUrl(string id)
    {
        var url = _context.Urls.SingleOrDefault(u => u.UrlId == id);

        if (url == null)
        {
            return "Shortened URL not found.";
        }

        return url.ShortenedUrl;
    }
    [AllowAnonymous]
    [HttpGet("original/url/{shortUrl}")]
    public string GetOriginalUrl(string shortUrl)
    {
        var url = _context.Urls.SingleOrDefault(u => u.ShortenedUrl == shortUrl);

        if (url == null)
        {
            return "Shortened URL not found.";
        }

        return url.OriginalUrl;
    }

    [HttpGet]
    public List<string> List()
    {
        Console.WriteLine($"request to list");

        return
        [
            "url1",
            "url2"
        ];
    }
}
