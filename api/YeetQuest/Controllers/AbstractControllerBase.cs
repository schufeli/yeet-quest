using KoBuApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace YeetQuest.Controllers
{
    [ApiController]
    public class AbstractControllerBase : ControllerBase
    {
        public ApplicationDbContext DbContext { get; set; }

        public AbstractControllerBase(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #region Responses
        internal ObjectResult NotFound(string name) =>
            Problem(title: $"{name} not found.",
                    statusCode: 404,
                    detail: $"{name} could not be found or does not exist",
                    instance: HttpContext.Request.Path);

        internal ObjectResult InvalidRequest(string name) =>
            Problem(title: $"Body content invalid {name} object!",
                    statusCode: 400,
                    detail: $"Please assure that you sent a valid {name} object",
                    instance: HttpContext.Request.Path);
        #endregion
    }
}
