using finanzas.Models;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Mvc.Filters {
    public class SessionFilter : IActionFilter {
        public void OnActionExecuting (ActionExecutingContext context) {
            string accionMetodo = (string) context.RouteData.Values["action"];
            string controlador = (string) context.RouteData.Values["controller"];
            if (context.HttpContext.Session.GetObject<User> ("UsuarioActivo") == null) {
                if (!(controlador == "Login")) {
                    context.Result = new RedirectToActionResult ("Index", "Login", null);
                }
            } else {
                if (controlador == "Login" && accionMetodo == "Index") {
                    context.Result = new RedirectToActionResult ("Index", "Home", null);
                }
            }
        }

        public void OnActionExecuted (ActionExecutedContext context) { }
    }
}