using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using finanzas.Models;
using Microsoft.AspNetCore.Mvc;

namespace finanzas.Controllers {
    public class HomeController : BaseController {
        public IActionResult Index () {
            return View ();
        }
    }
}