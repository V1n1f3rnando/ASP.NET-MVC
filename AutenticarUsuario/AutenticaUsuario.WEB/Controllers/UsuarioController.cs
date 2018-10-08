using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticaUsuario.WEB.Models;
using AutenticaUsuario.Entidades;
using AutenticaUsuario.WEB.Util;
using AutenticaUsuario.DAL.Repositories;

namespace AutenticaUsuario.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        // POST: Usuario/Cadastro

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(UsuarioCadastroViewModel model)
        {
            //verificar se os dados da model passaram nas validações..
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = new Usuario();
                    u.Nome = model.Nome;
                    u.Login = model.Login;
                    u.Senha = Util.Md5.Encryptar(model.Senha);
                    UsuarioRepositorio rep = new UsuarioRepositorio();
                    if (! rep.HasLogin(model.Login))
                    {
                        rep.Insert(u); //gravando..
                        ModelState.Clear(); //limpando os campos..
                        ViewBag.Mensagem = $"Usuário {u.Nome}, cadastrado com sucesso.";
                    }
                    else
                    {
                        throw new Exception("Login já existe, tente outro por favor !");
                    }
              
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }
        // GET: Usuario/Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Login(UsuarioLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepositorio rep = new UsuarioRepositorio();
                    Usuario u = rep.Find(model.Login, Util.Md5.Encryptar(model.Senha));

                    if (u != null)
                    {
                        ViewBag.Mensagem = "Usuário encontrado."; //Provisório!!
                    }
                    else
                    {
                        ViewBag.Mensagem = "Acesso Negado.";
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return View();
        }
    }
}
    