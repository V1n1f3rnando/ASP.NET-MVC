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
            return View();
        }
    }
}