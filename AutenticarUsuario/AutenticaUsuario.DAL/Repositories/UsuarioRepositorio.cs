using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutenticaUsuario.DAL.Context;
using AutenticaUsuario.Entidades;

namespace AutenticaUsuario.DAL.Repositories
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>
    {
        public Usuario Find(string login, string senha)
        {
            using (DataContext d = new DataContext())
            {
                //SQL -> select * from Usuario
                // where Login = @Login and Senha = @Senha
                return d.Usuario
                .FirstOrDefault(u => u.Login.Equals(login)
                && u.Senha.Equals(senha));
            }
        }
    }
}
