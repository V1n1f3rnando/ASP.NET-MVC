using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticaUsuario.WEB.Filters;

namespace AutenticaUsuario.WEB.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        [NoCache]
        public ActionResult Index()
        {
            return View();
        }
    }
}