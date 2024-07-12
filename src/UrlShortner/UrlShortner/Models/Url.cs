using System;
using System.ComponentModel.DataAnnotations;
namespace UrlShortner.Models
{
    public class Url
    {
        public string UrlId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(2000)]
        public string OriginalUrl { get; set; }

        [Required]
        [StringLength(50)]
        public string ShortenedUrl { get; set; }
    }
}