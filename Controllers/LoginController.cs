using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using finanzas.Models;
using Microsoft.AspNetCore.Mvc;

namespace finanzas.Controllers {
    public class LoginController : BaseController {
        public IActionResult Index () {
            ViewBag.Title = "Autenticación";
            return View ();
        }

        [HttpPost]
        [ActionName ("__ClAS95dOSvCL")]
        public JsonResult Login (string user, string password) {
            try {
                UsuarioActivo = null;
                if (string.IsNullOrEmpty (user)) {
                    throw new ArgumentException ("The field is empty", nameof (user));
                }

                if (string.IsNullOrEmpty (password)) {
                    throw new ArgumentException ("The field is empty", nameof (password));
                }

                if ((user == "User1") && (password == "Clave123+.")) {
                    UsuarioActivo = new User () { name = user };
                    return Json (data: true);
                }
                return Json (data: false);
            } catch (Exception ex) {
                return Json (data: ex.Message);
            }
        }

        public IActionResult SingOut () {
            UsuarioActivo = null;
            return RedirectToAction ("Index");
        }
    }
}