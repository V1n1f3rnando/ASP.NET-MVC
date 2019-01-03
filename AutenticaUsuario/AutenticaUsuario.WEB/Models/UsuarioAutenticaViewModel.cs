using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticaUsuario.WEB.Models
{
    public class UsuarioAutenticaViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome  { get; set; }
        public string Login { get; set; }
        public DateTime DataHoraAcesso  { get; set; }
        public string Perfil { get; set; }
    }
}