using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;

namespace UrlShortner.Controllers;

[Authorize(AuthenticationSchemes = $"BasicAuthentication")]
[ApiController]
[Route("[controller]")]
public class NavigateController : ControllerBase
{
    private readonly UrlShortenerContext _context;
    public NavigateController(UrlShortenerContext context)
    {
        _context = context;
    }
    
    [AllowAnonymous]
    [HttpGet("{shortUrl}")]
    public RedirectResult Navigate(string shortUrl)
    {
        Console.WriteLine($"request to navigate for {shortUrl}");

        var url = _context.Urls.SingleOrDefault(u => u.ShortenedUrl.Contains(shortUrl));

        return url == null ? Redirect("https://www.google.com") : Redirect(url.OriginalUrl);
    }
}
