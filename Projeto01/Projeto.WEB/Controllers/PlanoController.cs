using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto01.Entidades;
using Projeto.DAL.Repositorios;


namespace Projeto.WEB.Controllers
{
    public class PlanoController : Controller
    {
        // GET: Plano
        public ActionResult Cadastro(PlanoCadastroViewModel model)
        {
            try
            {
                //verificando se houve erros na validação
                if (ModelState.IsValid)
                {
                    //Objeto da classe entidade
                    Plano p = new Plano();

                    p.Nome = model.Nome;
                    p.Descricao = model.Descricao;

                    //Gravando no banco
                    PlanoRepositorio rep = new PlanoRepositorio();
                    rep.Inserir(p);

                    ViewBag.Mensgaem = $"Plano:{p.Nome}, cadastrado com sucesso !";

                    ModelState.Clear(); // Limpando os campos
                    
                }
            }
            catch (Exception ex)
            {

                ViewBag.Mensagem = $"Erro: "+ex.Message;
            }

            return View();
        }

        public ActionResult Consulta()
        {
            return View();
        }
    }
}