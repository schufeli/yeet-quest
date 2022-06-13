using KoBuApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YeetQuest.ActionFilters;
using YeetQuest.Controllers.Filters;
using YeetQuest.Controllers.Responses;
using YeetQuest.Entities.Models;

namespace YeetQuest.Controllers
{
    [Route("api/users")]
    public class UserController : AbstractControllerBase
    {
        public UserController(ApplicationDbContext context) : base(context) { }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter paginationFilter)
        {
            var filter = new PaginationFilter(paginationFilter.Start, paginationFilter.Limit);

            var elements = await DbContext.Users
                .OrderBy(e => e.Index)
                .Skip((filter.Start - 1) * filter.Limit)
                .Take(filter.Limit)
                .ToListAsync();

            var records = await DbContext.Chats.CountAsync();

            return new JsonResult(
                new PagedResponse<List<User>>(data: elements, totalRecords: records, count: elements.Count()));
        }

        [HttpGet("{id}")]
        [ValidateGuidParameter]
        public IActionResult Get(string id)
        {
            var element = DbContext.Users
                .SingleOrDefault(e => e.Id == Guid.Parse(id));

            if (element == null)
                return NotFound("User");

            return new JsonResult(
                new Response<User>(element));
        }

        [HttpGet("{id}/chats")]
        [ValidateGuidParameter]
        public IActionResult GetUserWithChats(string id)
        {
            var element = DbContext.Users
                .Include(u => u.Chats)
                .SingleOrDefault(e => e.Id == Guid.Parse(id));

            if (element == null)
                return NotFound("User");

            return new JsonResult(
                new Response<User>(element));
        }

        [HttpPost]
        public IActionResult Login([FromBody] User model)
        {
            var element = DbContext.Users
                .SingleOrDefault(e => e.Name == model.Name);

            if (element == null)
            {
                DbContext.Users.Add(model);
                DbContext.SaveChanges();

                var user = DbContext.Users
                    .SingleOrDefault(u => u.Name == model.Name);

                return new JsonResult(
                   new Response<User>(user));
            }
            else
            {
                return new JsonResult(
                   new Response<User>(element));
            }
        }
    }
}
