using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto01.Entidades;
using Projeto.WEB.Models;
using Projeto.DAL.Repositorios;
using Projeto01.Entidades.Tipos;

namespace Projeto.WEB.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cadastro( )
        {
            ClienteCadastroViewModel viewModel = new ClienteCadastroViewModel();
            viewModel.ListagemDePlanos = ObterPlanos();

            //Enviando a model para a página
            return View(viewModel);
        }

        //Post: Cliente/Cadastro
        [HttpPost]
        public ActionResult Cadastro(ClienteCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                //mensagem 
                ViewBag.Mensagem = "Cliente cadastrado com sucesso.";
            }

            ClienteCadastroViewModel viewModel = new ClienteCadastroViewModel();
            viewModel.ListagemDePlanos = ObterPlanos();

            return View(viewModel);
        }


        public ActionResult Consulta()
        {
            return View();
        }

        //Método para obter os planos
        private List<SelectListItem> ObterPlanos()
        {
            List<SelectListItem> lista = new List<SelectListItem>();

            //acessando a base de dados..
            PlanoRepositorio rep = new PlanoRepositorio();
            foreach (var p in rep.Buscar())
            {
                SelectListItem item = new SelectListItem();
                item.Value = p.IdPlano.ToString();
                item.Text = p.Nome;

                lista.Add(item);
            }

            return lista;
        }
    }
}