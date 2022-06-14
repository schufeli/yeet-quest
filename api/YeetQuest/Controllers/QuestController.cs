using KoBuApp.Entities;
using Microsoft.AspNetCore.Mvc;
using YeetQuest.Controllers.Responses;
using YeetQuest.Entities.Models;

namespace YeetQuest.Controllers
{
    [Route("api/quests")]
    public class QuestController : AbstractControllerBase
    {
        public QuestController(ApplicationDbContext context) : base(context) { }

        [HttpPost]
        public IActionResult Post([FromBody] Quest model)
        {
            DbContext.Quests.Add(model);
            DbContext.SaveChanges();

            return new JsonResult(
                new Response<Quest>(model));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Quest model)
        {
            var element = DbContext.Quests
                .SingleOrDefault(e => e.Id == model.Id);

            if (element == null)
                return NotFound("Quest");

            element.DueDate = model.DueDate;
            element.AssigneId = model.AssigneId;
            element.Content = model.Content;
            element.IsCompleted = model.IsCompleted;

            DbContext.SaveChanges();

            return new JsonResult(
                new Response<Quest>(element));
        }
    }
}
