using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutenticaUsuario.WEB.Models
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        [Display(Name = "Nome do Usuario:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe seu login de acesso.")]
        [Display(Name = "Login de Acesso:")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Por favor, informe sua senha de acesso.")]
        [Display(Name = "Senha de Acesso:")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Required(ErrorMessage = "Por favor, confirme sua senha de acesso.")]
        [Display(Name = "Confirmação de Senha:")]
        public string SenhaConfirm { get; set; }
    }
}