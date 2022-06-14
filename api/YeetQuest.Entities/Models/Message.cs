using System.ComponentModel.DataAnnotations;

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
        public User? Author { get; set; }
        public Guid ChatId { get; set; }
        public Chat? Chat { get; set; }
    }
}
