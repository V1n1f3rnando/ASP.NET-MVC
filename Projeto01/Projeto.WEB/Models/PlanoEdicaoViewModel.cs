using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class PlanoEdicaoViewModel
    {
        [Required(ErrorMessage = "Informe o id do plano.")]
        public int IdPlano { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o nome do plano.")]
        public string Nome { get; set; }

        [MinLength(3, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(253, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a descrição do plano.")]
        public string Descricao { get; set; }

    }
}