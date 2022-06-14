using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YeetQuest.ActionFilters
{
    public class ValidateGuidParameter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey("id"))
            {
                if (!Guid.TryParse((context.ActionArguments["id"] as string), out var id))
                {
                    context.Result = new ObjectResult(
                        new ProblemDetails()
                        {
                            Title = "Invalid id format.",
                            Status = 400,
                            Detail = "Id could not be formated please provide a valid id."
                        });
                    return;
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
