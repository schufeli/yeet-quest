using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YeetQuest.Entities.Models
{
    public class Quest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string? Content { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime DueDate { get; set; } = DateTime.Now;
        public Guid AssigneId { get; set; }
        public User? Assigne { get; set; }
        public Guid ChatId { get; set; }
        public Chat? Chat { get; set; }
    }
}