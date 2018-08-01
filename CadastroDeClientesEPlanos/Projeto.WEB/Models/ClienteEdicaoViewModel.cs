using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto01.Entidades.Tipos;
using System.Web.Mvc;
using Projeto01.Entidades;


namespace Projeto.WEB.Models
{
    public class ClienteEdicaoViewModel
    {

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public int IdPlano { get; set; }
        public List<SelectListItem> ListaDePlanos { get; set; }

    }
}