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

        public JsonResult ConsultarClientes()
        {
            try
            {
                List<ClienteConsultaViewModel> lista = new List<ClienteConsultaViewModel>();

                //varrendo clientes obtidos no banco 
                ClienteRepositorio rep = new ClienteRepositorio();

                foreach (Cliente c in rep.Buscar())
                {
                    ClienteConsultaViewModel model = new ClienteConsultaViewModel();
                    model.IdCliente = c.IdCliente;
                    model.Nome = c.Nome;
                    model.Email = c.Email;
                    model.Sexo = c.Sexo.ToString();
                    model.EstadoCivil = c.EstadoCivil.ToString();

                    lista.Add(model);
                }

                //JsonRequestBehavior.Allo
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json("Erro: " + ex.Message, JsonRequestBehavior.AllowGet);
                
            }
        }
    }
}