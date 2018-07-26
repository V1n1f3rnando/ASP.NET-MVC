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

                    ViewBag.Mensagem = $"Plano: {p.Nome}, cadastrado com sucesso !";

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
            //declrando lista da classe modelo
            List<PlanoConsultaViewModel> lista = new List<PlanoConsultaViewModel>();

            try
            {
                PlanoRepositorio rep = new PlanoRepositorio();

                foreach (var p in rep.Buscar())
                {
                    PlanoConsultaViewModel model = new PlanoConsultaViewModel();
                    model.IdPlano = p.IdPlano;
                    model.Nome = p.Nome;
                    model.Descricao = p.Descricao;

                    lista.Add(model); //Adicionar na lista 
                }
            }
            catch (Exception ex)
            {

                ViewBag.Mensagem = "Erro:" + ex.Message;
            }


            return View(lista);
        }

        public ActionResult Edicao()
        {
            return View();
        }
    }
}