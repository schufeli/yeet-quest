using System.ComponentModel.DataAnnotations;

namespace YeetQuest.Entities.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Index { get; set; }
        public string? Name { get; set; }
        public virtual List<Chat>? Chats { get; set; }
        public virtual List<Quest>? Quests { get; set; }
        public virtual List<Message>? Messages { get; set; }
    }
}