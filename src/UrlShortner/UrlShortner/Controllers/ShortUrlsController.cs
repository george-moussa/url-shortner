using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Controllers;

[Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},BasicAuthentication")]
[ApiController]
[Route("[controller]")]
public class ShortUrlsController : ControllerBase
{
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
        Console.WriteLine($"request to get: {id}");
        return "shortUrl";
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
