using KoBuApp.Entities;
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
            DbContext.Messages.Add(message);
            await DbContext.SaveChangesAsync();

            await Clients.Group(chatId).SendAsync("ReceiveMessage", message);
        }
    }
}
