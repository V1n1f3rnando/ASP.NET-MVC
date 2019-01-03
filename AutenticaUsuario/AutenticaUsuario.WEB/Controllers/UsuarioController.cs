using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticaUsuario.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}