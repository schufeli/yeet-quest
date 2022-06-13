using Microsoft.EntityFrameworkCore;
using YeetQuest.Entities.Models;

namespace KoBuApp.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Chat
            builder.Entity<Chat>().ToTable("Chats");

            builder.Entity<Chat>()
                .HasMany(c => c.Messages)
                .WithOne(m => m.Chat);

            builder.Entity<Chat>()
                .HasMany(c => c.Users)
                .WithMany(u => u.Chats);

            builder.Entity<Chat>()
                .HasMany(c => c.Quests)
                .WithOne(q => q.Chat);
            #endregion

            #region Message
            builder.Entity<Message>().ToTable("Messages");

            builder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId);

            builder.Entity<Message>()
                .HasOne(m => m.Author)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.AuthorId);
            #endregion

            #region Quest
            builder.Entity<Quest>().ToTable("Quests");

            builder.Entity<Quest>()
                .HasOne(q => q.Chat)
                .WithMany(c => c.Quests)
                .HasForeignKey(q => q.ChatId);

            builder.Entity<Quest>()
                .HasOne(q => q.Assigne)
                .WithMany(u => u.Quests)
                .HasForeignKey(q => q.AssigneId);
            #endregion

            #region User
            builder.Entity<User>().ToTable("Users");

            builder.Entity<User>()
                .HasMany(u => u.Chats)
                .WithMany(c => c.Users);

            builder.Entity<User>()
                .HasMany(u => u.Quests)
                .WithOne(q => q.Assigne);

            builder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.Author);
            #endregion

            base.OnModelCreating(builder);
        }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
