using System.ComponentModel.DataAnnotations;

namespace YeetQuest.Entities.Models
{
    public class Chat
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Index { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        public virtual List<Message>? Messages { get; set; }
        public virtual List<User>? Users { get; set; }
        public virtual List<Quest>? Quests { get; set; }
    }
}
