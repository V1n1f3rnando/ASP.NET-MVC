using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto01.Entidades.Tipos;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class ClienteCadastroViewModel
    {

        //Validações
        [Required(ErrorMessage = "Por favor, informe um nome.")]
        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe um email.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sexo do cliente")]
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o estado civíl do cliente")]
        public EstadoCivil EstadoCivil { get; set; }

    }
}