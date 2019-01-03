using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutenticaUsuario.WEB.Models
{
    public class UsuarioLoginViewModel
    {
        [Required(ErrorMessage ="Informe o login de acesso !")]
        [Display(Name ="Login de acesso")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informe a sua senha !")]
        [Display(Name = "Senha de acesso")]
        public string Senha { get; set; }
    }
}