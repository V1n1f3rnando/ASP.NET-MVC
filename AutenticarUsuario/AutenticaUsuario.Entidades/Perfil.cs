using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutenticaUsuario.Entidades
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Nome { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}
