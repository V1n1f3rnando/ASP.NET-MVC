using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto.DAL.Repositorio;
using Projeto.Entidades;
using Projeto.Entidades.Tipos;

namespace Projeto.WEB.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Cliente/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        //Método para responder a requisição AJAX do Jquery
        public JsonResult CadastrarCliente(ClienteCadastroViewModel model)
        {
            try
            {
                ClienteRepositorio rep = new ClienteRepositorio();

                if (! rep.VerificaEmail(model.Email))
                {
                    var c = new Cliente();

                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Sexo = model.Sexo;
                    c.EstadoCivil = model.EstadoCivil;

                    rep.Inserir(c); // Gravando... 

                    return Json($"Cliente {c.Nome}, cadastrado com sucesso !");
                }
                else
                {
                    throw new Exception($"O email {model.Email}, já foi cadastrado.");
                }
            }
            catch (Exception e )
            {
                //Retonando erro !
                return Json("Erro: " + e.Message);
            }
        }
    }
}