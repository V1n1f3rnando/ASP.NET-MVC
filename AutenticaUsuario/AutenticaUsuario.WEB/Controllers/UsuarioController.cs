using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticaUsuario.WEB.Models;
using AutenticaUsuario.Entidades;
using AutenticaUsuario.WEB.Util;
using AutenticaUsuario.Repositorio.Repositories;
using System.Web.Security;
using Newtonsoft.Json;

namespace AutenticaUsuario.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro( UsuarioCadastroViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Usuario usuario = new Usuario();

                    usuario.Login = model.Login;
                    usuario.Nome = model.Nome;
                    usuario.Senha = Criptografia.EncriptarSenha(model.Senha);
               
                    UsuarioRepositorio rep = new UsuarioRepositorio();

                    if (! rep.HasLogin(usuario.Login))
                    {
                        rep.Insert(usuario);
                        ViewBag.Mensagem = $"Usuário {usuario.Login}, foi cadastrado com sucesso !";
                    }
                    else
                    {
                        throw new Exception($"Usuário {usuario.Login} já existe no sistema, por favor selecione outro !");
                    }
                    

                    
                    ModelState.Clear();
               
                }
                catch (Exception ex)
                {
                    ViewBag.Mensagem = "Erro:"+ex.Message;
                }
            }


            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio rep = new UsuarioRepositorio();
                    Usuario usuario = rep.Find(model.Login, Criptografia.EncriptarSenha(model.Senha));

                    if (usuario != null)
                    {
                        UsuarioAutenticaViewModel auth = new UsuarioAutenticaViewModel();
                        auth.IdUsuario = usuario.IdUsuario;
                        auth.Nome = usuario.Nome;
                        auth.Login = usuario.Login;
                        auth.DataHoraAcesso = DateTime.Now;
                        auth.Perfil = string.Empty;

                        //gerando ticket de acesso 
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(JsonConvert.SerializeObject(auth), true, 5);

                        //gravando o ticket em cookie
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                        cookie.Expires = DateTime.Now.AddMinutes(10);
                        Response.Cookies.Add(cookie);//gravado no navegador 

                        //redirecionar para a página do administrador
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.Mensagem = "Acesso negado !";
                    }
                }
                catch (Exception ex)
                {

                    ViewBag.Mensagem = $"Erro: {ex.Message}";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            //Destruir o ticket de acesso !
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}