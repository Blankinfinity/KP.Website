using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace KP.Presentation.UI.ActionFilters
{
    public class RequireSslFilterAction : ActionFilterAttribute
    {
        // TODO: Need to test
        // Requiring SSL for MVC Controllers article by Dan Wahlin (for asp.net mvc 11/10/2009)
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequest req = filterContext.HttpContext.Request;
            HttpResponse res = filterContext.HttpContext.Response;

            //Check if we're secure or not and if we're on the local box
            if (!req.IsHttps && !req.Host.Value.Contains("localhost"))
            {
                string url = req.GetDisplayUrl().ToLower()
                    .Replace("http:", "https:");
                res.Redirect(url);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
