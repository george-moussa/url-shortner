using Microsoft.EntityFrameworkCore;
using UrlShortner.Models;

namespace UrlShortener.Models
{
    public class UrlShortenerContext : DbContext
    {
        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options)
        {
        }
        public DbSet<Url> Urls { get; set; }
    }
}