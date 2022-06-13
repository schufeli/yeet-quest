using KoBuApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YeetQuest.ActionFilters;
using YeetQuest.Controllers.Filters;
using YeetQuest.Controllers.Responses;
using YeetQuest.Entities.Models;

namespace YeetQuest.Controllers
{
    [Route("api/chats")]
    public class ChatController : AbstractControllerBase
    {
        public ChatController(ApplicationDbContext context) : base(context) { }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var filter = new PaginationFilter(paginationFilter.Start, paginationFilter.Limit);

            var elements = await DbContext.Chats
                .OrderBy(e => e.Index)
                .Skip((filter.Start - 1) * filter.Limit)
                .Take(filter.Limit)
                .ToListAsync();

            var records = await DbContext.Chats.CountAsync();

            return new JsonResult(
                new PagedResponse<List<Chat>>(data: elements, totalRecords: records, count: elements.Count()));
        }

        [HttpGet("{id}")]
        [ValidateGuidParameter]
        public IActionResult Get(string id)
        {
            var element = DbContext.Chats
                .SingleOrDefault(e => e.Id == Guid.Parse(id));

            if (element.Equals(null))
                return NotFound("Chat");

            return new JsonResult(
                new Response<Chat>(element));
        }

        [HttpGet("{id}/messages")]
        [ValidateGuidParameter]
        public IActionResult GetChatWithMessages(string id) 
        {
            var element = DbContext.Chats
                .Include(e => e.Messages)
                .Where(e => e.Id.Equals(Guid.Parse(id)))
                .SingleOrDefault();

            if (element.Equals(null))
                return NotFound("Chat");

            return new JsonResult(
                new Response<Chat>(element));
        }

        [HttpGet("{id}/quests")]
        [ValidateGuidParameter]
        public IActionResult GetChatWithQuest(string id)
        {
            var element = DbContext.Chats
                .Include(e => e.Quests)
                .Where(e => e.Id.Equals(Guid.Parse(id)))
                .SingleOrDefault();

            if (element.Equals(null))
                return NotFound("Chat");

            return new JsonResult(
                new Response<Chat>(element));
        }

        [HttpGet("{id}/users")]
        [ValidateGuidParameter]
        public IActionResult GetChatWithUsers(string id)
        {
            var element = DbContext.Chats
                .Include(e => e.Users)
                .Where(e => e.Id.Equals(Guid.Parse(id)))
                .SingleOrDefault();

            if (element.Equals(null))
                return NotFound("Chat");

            return new JsonResult(
                new Response<Chat>(element));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Chat model)
        {
            DbContext.Chats.Add(model);
            DbContext.SaveChanges();

            return new JsonResult(
                new Response<Chat>(model));
        }

        [HttpPut("{id}/add")]
        [ValidateGuidParameter]
        public IActionResult AddUser(string id, [FromBody] List<User> models)
        {
            var element = DbContext.Chats
                .Include(c => c.Users)
                .SingleOrDefault(c => c.Id == Guid.Parse(id));

            if (element.Equals(null))
                return NotFound("Chat");

            foreach (var model in models)
            {
                var user = DbContext.Users
                    .SingleOrDefault(u => u.Name == model.Name);

                if (user != null && !element.Users.Contains(user))
                {
                    element.Users.Add(user);
                }
            }

            DbContext.SaveChanges();
             
            return new OkResult();
        }

        [HttpPut("{id}/remove")]
        [ValidateGuidParameter]
        public IActionResult RemoveUser(string id, [FromBody] List<User> models)
        {
            var element = DbContext.Chats
                .Include(c => c.Users)
                .SingleOrDefault(c => c.Id == Guid.Parse(id));

            if (element.Equals(null))
                return NotFound("Chat");

            foreach (var model in models)
            {
                var user = DbContext.Users
                    .SingleOrDefault(u => u.Name == model.Name);

                if (user != null && element.Users.Contains(user))
                {
                    element.Users.Remove(user);
                }
            }

            DbContext.SaveChanges();

            return new OkResult();
        }
    }
}
