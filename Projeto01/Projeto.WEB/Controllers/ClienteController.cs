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
                try
                {
                    Cliente c = new Cliente();
                    c.Plano = new Plano();

                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Sexo = model.Sexo;
                    c.EstadoCivil = model.EstadoCivil;
                    c.DataCadastro = DateTime.Now;
                    c.Plano.IdPlano = model.IdPlano;

                    ClienteRepositorio rep = new ClienteRepositorio();
                    rep.Inserir(c);

                    //mensagem 
                    ViewBag.Mensagem = "Cliente cadastrado com sucesso.";
                }
                catch (Exception ex)
                {

                    ViewBag.Mensagem = "Erro: " + ex.Message;
                }
                

               
            }

            ClienteCadastroViewModel viewModel = new ClienteCadastroViewModel();
            viewModel.ListagemDePlanos = ObterPlanos();

            return View(viewModel);
        }


        public ActionResult Consulta()
        {
            List<ClienteConsultaViewModel> lista = new List<ClienteConsultaViewModel>();

            try
            {
                //Varrendo a consulta de cliente
                ClienteRepositorio rep = new ClienteRepositorio();

                foreach (var i in rep.Buscar())
                {
                    ClienteConsultaViewModel model = new ClienteConsultaViewModel();

                    model.IdCliente = i.IdCliente;
                    model.Nome = i.Nome;
                    model.Email = i.Email;
                    model.Sexo = i.Sexo;
                    model.EstadoCivil = i.EstadoCivil;
                    model.DataCadastro = i.DataCadastro;
                    model.IdPlano = i.Plano.IdPlano;
                    model.NomePlano = i.Plano.Nome;

                    lista.Add(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro " + ex.Message;
            }
            return View(lista);
        }

        public ActionResult Edicao(int id)
        {
            ClienteEdicaoViewModel model = new ClienteEdicaoViewModel();

            try
            {
                ClienteRepositorio rep = new ClienteRepositorio();
                Cliente c = new Cliente();
              
                c = rep.BuscarPorId(id);

                model.IdCliente = id;
                model.Nome = c.Nome;
                model.Email = c.Email;
                model.Sexo = c.Sexo;
                model.EstadoCivil = c.EstadoCivil;
                model.IdPlano = c.Plano.IdPlano;
                
            }
            catch (Exception ex)
            {

                ViewBag.Mensagem = "Erro " + ex.Message;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edicao(ClienteEdicaoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente c = new Cliente();
                    c.Plano = new Plano();

                    c.IdCliente = model.IdCliente;
                    c.Nome = model.Nome;
                    c.Email = model.Email;
                    c.Sexo = model.Sexo;
                    c.EstadoCivil = model.EstadoCivil;
                    c.Plano.IdPlano = model.IdPlano;

                    ClienteRepositorio rep = new ClienteRepositorio();

                    rep.Alterar(c);

                    ViewBag.Mensagem = "Dados atualizados com sucesso !";
                }
              

            }
            catch (Exception ex)
            {

                ViewBag.Mensagem = "Erro " + ex.Message;
            }
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