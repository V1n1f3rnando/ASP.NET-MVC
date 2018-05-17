using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // Validações

namespace Estudo01.Models
{
    public class PlanoCadastroViewModel
    {
        //Validando campos ! 

        [MinLength(3, ErrorMessage = "Informe no minimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]

        [Required(ErrorMessage = "Informe o nome do plano.")]
        public string Nome { get; set; }  

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres")]
        [MaxLength(250, ErrorMessage = "Informe no máximo {1} carcteres")]

        [Required(ErrorMessage = "Informe a descrição do plano.")]
        public string Descricao { get; set; }
    }
}