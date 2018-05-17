using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.Entidades;// Imports
using Projeto.DAL.Repositorios; //Imports
using Estudo01.Models; //Imports

namespace Estudo01.Controllers
{
    public class PlanoController : Controller
    {
        // GET: Plano
        public ActionResult Cadastro()
        {
            return View();

        }

        [HttpPost] // Recebendo requisição do tipo post para o submit do botão de cadastro
        public ActionResult Cadastro(PlanoCadastroViewModel model)
        {
            try
            {
                //Verificando erros na validação
                if (ModelState.IsValid)
                {
                    Plano p = new Plano();

                    p.Nome = model.Nome;
                    p.Descricao = model.Descricao;

                    // Gravando no banco
                    PlanoRepositorio rep = new PlanoRepositorio();
                    rep.Inserir(p);

                    ViewBag.Mensagem = $"Plano:{p.Nome}, cadastrado com sucesso !";

                    ModelState.Clear();
                }
            }
            catch (Exception e)
            {

                //Exibindo erro na página
                ViewBag.Mensagem = "Ocorreu um erro"+ e.Message;
            }

            return View();
        }

        public ActionResult Consulta()
        {
            //Declarando uma lista da classe model
            List<PlanoConsultaViewModel> lista = 
                new List<PlanoConsultaViewModel>();

            try
            {
                PlanoRepositorio rep = new PlanoRepositorio();
                foreach (Plano p  in rep.Listar() )
                {
                    PlanoConsultaViewModel model = 
                        new PlanoConsultaViewModel();

                    model.IdPlano = p.IdPlano;
                    model.Nome = p.Nome;
                    model.Descricao = p.Descricao;

                    lista.Add(model); //adicionar na lista
                }
            }
            catch (Exception e)
            {

                ViewBag.Mensagem = "Erro: " + e.Message;
            }

            return View(lista); //Enviando a lista
        }
    }
}