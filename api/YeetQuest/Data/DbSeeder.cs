using KoBuApp.Entities;
using YeetQuest.Entities.Models;

namespace YeetQuest.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            if (!dbContext.Chats.Any()) SeedChats(dbContext);

            dbContext.SaveChanges();
        }

        private static void SeedChats(ApplicationDbContext dbContext)
        {
            dbContext.Chats.AddRange(GetChats(dbContext));
        }

        private static List<Chat> GetChats(ApplicationDbContext dbContext)
        {
            return new List<Chat>
            {
                new Chat
                {
                    Id = Guid.Parse("6cd112bd-e094-424e-94d0-8318ff56a02b"),
                    Name = "BBZW Treasure",
                    Description = "BBZW chat to share information related to exams",
                    Messages = new List<Message>()
                    {
                        new Message
                        {
                            Id = Guid.Parse("b87b68ad-5ead-4b24-a639-c6a03f380135"),
                            Content = "Does someone now what SW15 is?",
                            CreatedDateTime = DateTime.Now,
                            ChatId = Guid.Parse("6cd112bd-e094-424e-94d0-8318ff56a02b"),
                            AuthorId = Guid.Parse("e3db95b1-4574-4259-9a1f-afcc2f8ffb48"),
                            AuthorName = "JoeMama"
                        },
                        new Message
                        {
                            Id = Guid.Parse("5ebdfa65-e8c4-47a1-9636-d37b332e17c0"),
                            Content = "No",
                            CreatedDateTime= DateTime.Now.AddMinutes(25),
                            ChatId = Guid.Parse("6cd112bd-e094-424e-94d0-8318ff56a02b"),
                            AuthorId = Guid.Parse("c1379aae-d5bf-40e9-a191-56e184298bea"),
                            AuthorName = "Jaejer"
                        }
                    },
                    Quests = new List<Quest>
                    {
                        new Quest
                        {
                            Id = Guid.Parse("5a046130-7cee-43ac-bf9a-13941deb4e41"),
                            Content = "Bring some pens",
                            DueDate = DateTime.Now.AddDays(4),
                            ChatId = Guid.Parse("6cd112bd-e094-424e-94d0-8318ff56a02b"),
                            AssigneId = Guid.Parse("c1379aae-d5bf-40e9-a191-56e184298bea")
                        }
                    },
                    Users = new List<User>()
                    {
                        new User
                        {
                            Id = Guid.Parse("e3db95b1-4574-4259-9a1f-afcc2f8ffb48"),
                            Name = "JoeMama"
                        },
                        new User
                        {
                            Id = Guid.Parse("c1379aae-d5bf-40e9-a191-56e184298bea"),
                            Name = "Jaejer"
                        }
                    }
                }
            };
        }
    }
}
