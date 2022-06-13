using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YeetQuest.Entities.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Content { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public Guid AuthorId { get; set; }
        [JsonIgnore]
        public User? Author { get; set; }
        public Guid ChatId { get; set; }
        [JsonIgnore]
        public Chat? Chat { get; set; }
    }
}
