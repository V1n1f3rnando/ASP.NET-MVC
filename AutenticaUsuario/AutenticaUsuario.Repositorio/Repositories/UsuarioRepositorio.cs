using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutenticaUsuario.Entidades;
using AutenticaUsuario.Repositorio.Context;

namespace AutenticaUsuario.Repositorio.Repositories
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>
    {
        public Usuario Find(string login, string senha)
        {
            using(DataContex d = new DataContex())
            {

                //SQL -> select * from Usuario
                // where Login = @Login and Senha = @Senha
                return d.Usuario
                    .FirstOrDefault(u => u.Login.Equals(login) && (u.Senha.Equals(senha)));
            }
        }

        public bool HasLogin(string login)
        {
            using(DataContex d = new DataContex())
            {
                return d.Usuario.Count(u => u.Login.Equals(login)) > 0;
            }
        }
    }
}
