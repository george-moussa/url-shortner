using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlsController : ControllerBase
    {
        private readonly ILogger<ShortUrlsController> _logger;

        public ShortUrlsController(ILogger<ShortUrlsController> logger)
        {
            _logger = logger;
        }

        [HttpPut("{id}")]
        public string CreateShortUrl(string id, [FromBody] JsonElement body)
        {
            Console.WriteLine($"request to create: {id}, {body.GetProperty("url")}");
            return "https://shortUrl.com";
        }

        [HttpDelete("{id}")]
        public string DeleteShortUrl(string id)
        {
            Console.WriteLine($"request to delete: {id}");
            return "deleted!";
        }

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
}
