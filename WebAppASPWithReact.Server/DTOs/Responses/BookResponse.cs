using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAppASPWithReact.Server.DTOs.Responses
{
    public class BookResponse
    {
        [JsonPropertyName("book_id")]
        public int BookId { get; set; }


        [JsonPropertyName("book_name")]
        public string BookName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("publication_date")]
        public DateTime PublicationDate { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; } = null!;

        [JsonPropertyName("book_category_id")]
        public int BookCategoryId { get; set; }
    }
}
