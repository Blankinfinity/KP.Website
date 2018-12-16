using KP.Presentation.UI.ApiResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KP.Presentation.UI.ActionFilters
{
    /// <summary>
    /// Centralizing Validation Logic
    /// This reduces the size of our actions, removes duplicated code and improves consistency
    /// </summary>
    public class ApiValidationFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // TODO: Implement logging
                // _logger.LogError("Invalid object sent from client.");
                context.Result = new BadRequestObjectResult(new ApiBadRequestResponse(context.ModelState));
            }

            base.OnActionExecuting(context);
        }
    }
}
