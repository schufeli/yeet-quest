using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YeetQuest.Entities.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public virtual List<Chat>? Chats { get; set; }
        public virtual List<Quest>? Quests { get; set; }
        public virtual List<Message>? Messages { get; set; }
    }
}