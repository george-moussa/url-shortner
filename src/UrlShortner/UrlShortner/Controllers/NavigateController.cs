using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortner.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NavigateController : ControllerBase
    {
        private readonly ILogger<NavigateController> _logger;

        public NavigateController(ILogger<NavigateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{shortUrl}")]
        public RedirectResult Navigate(string shortUrl)
        {
            Console.WriteLine($"request to navigate for {shortUrl}");
            return Redirect("https://www.google.com");
        }
    }
}
