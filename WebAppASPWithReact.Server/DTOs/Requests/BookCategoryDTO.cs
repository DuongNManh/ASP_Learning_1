using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAppASPWithReact.Server.DTOs.Requests
{
    public class BookCategoryDTO
    {
        [Required]
        [JsonPropertyName("book_gerne_type")]
        public string BookGenreType { get; set; } = null!;

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;
    }
}
