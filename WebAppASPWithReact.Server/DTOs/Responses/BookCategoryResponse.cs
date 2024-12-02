using System.Text.Json.Serialization;

namespace WebAppASPWithReact.Server.DTOs.Responses
{
    public class BookCategoryResponse
    {
        [JsonPropertyName("book_category_id")]
        public int BookCategoryId { get; set; }

        [JsonPropertyName("book_genre_type")]
        public string BookGenreType { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;
    }
}
