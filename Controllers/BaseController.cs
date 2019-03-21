using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using finanzas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace finanzas.Controllers {

    public class BaseController : Controller {
        public User UsuarioActivo {
            get {
                return ((User) HttpContext.Session.GetObject<User> ("UsuarioActivo") ?? null);
            }
            set {
                HttpContext.Session.SetObject ("UsuarioActivo", value);
            }
        }

    }
}