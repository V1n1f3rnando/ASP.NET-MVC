using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutenticaUsuario.WEB.Models
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o seu nome !")]
        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o login desejado !")]
        [Display(Name = "Login de acesso")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informe a senha de acesso !")]
        [Display(Name = "Senha de acesso")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        [Required(ErrorMessage = "Por favor confirme a sua senha !")]
        [Display(Name = "Confirmação de senha")]
        public string SenhaConfirm { get; set; }
    }
}