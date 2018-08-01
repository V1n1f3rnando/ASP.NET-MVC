using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Entidades.Tipos;

namespace Projeto.WEB.Models
{
    public class ClienteCadastroViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
    }
}