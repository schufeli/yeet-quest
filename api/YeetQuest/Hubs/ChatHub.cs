﻿using KoBuApp.Entities;
using Microsoft.AspNetCore.SignalR;
using YeetQuest.Entities.Models;

namespace YeetQuest.Hubs
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext DbContext { get; set; }

        public ChatHub(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HubMethodName("Join")]
        public async Task JoinChatAsync(string chatId)
        {
            Console.WriteLine($"{Context.ConnectionId} joined Chat: {chatId}");
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        [HubMethodName("Leave")]
        public async Task LeaveChatAsync(string chatId)
        {
            Console.WriteLine($"{Context.ConnectionId} left Chat: {chatId}");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        [HubMethodName("SendMessage")]
        public async Task SendMessageAsync(string chatId, Message message) 
        {
            var user = DbContext.Users.Where(u => u.Id == message.AuthorId).SingleOrDefault();

            if (user != null)
            {
                message.AuthorName = user.Name;

                DbContext.Messages.Add(message);
                await DbContext.SaveChangesAsync();

                var msg = new Message
                {
                    Id = message.Id,
                    AuthorId = message.AuthorId,
                    AuthorName = message.AuthorName,
                    ChatId = Guid.Parse(chatId),
                    Content = message.Content,
                    CreatedDateTime = message.CreatedDateTime
                };

                await Clients.Group(chatId).SendAsync("ReceiveMessage", msg);
            }
        }
    }
}
