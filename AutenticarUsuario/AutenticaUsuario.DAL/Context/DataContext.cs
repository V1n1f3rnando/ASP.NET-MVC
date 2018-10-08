using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutenticaUsuario.Entidades;
using AutenticaUsuario.DAL.Mappings;
using System.Configuration;


namespace AutenticaUsuario.DAL.Context
{
    //Regra 1 herdar dbcontext
    //Regra 1) Herdar DbContext..
    public class DataContext : DbContext
    {
        //Regra 2) Construtor enviando para o DbContext a connectionstring..
        public DataContext():base(ConfigurationManager.ConnectionStrings["BancoTeste"].ConnectionString)
        {
        }
        //Regra 3) Sobrescrever o método OnModelCreating..
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adicionando cada classe de mapeamento..
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PerfilMap());
        }
        //Regra 4) Declarar um DbSet para cada entidade..
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
    }


}
