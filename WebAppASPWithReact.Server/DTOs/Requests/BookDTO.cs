using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebAppASPWithReact.Server.Models;

namespace WebAppASPWithReact.Server.DTOs.Requests
{
    public class BookDTO
    {
        [Required]
        [JsonPropertyName("book_id")]
        public int BookId { get; set; }

        [Required]
        [JsonPropertyName("book_name")]
        public string BookName { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("publication_date")]
        public DateTime PublicationDate { get; set; }

        [Required]
        [JsonPropertyName("quantity")]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [JsonPropertyName("price")]
        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [JsonPropertyName("author")]
        public string Author { get; set; } = null!;

        [Required]
        [JsonPropertyName("book_category_id")]
        public int BookCategoryId { get; set; }
    }
}
