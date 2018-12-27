using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using AutenticaUsuario.Repositorio.Maps;
using AutenticaUsuario.Entidades;

namespace AutenticaUsuario.Repositorio.Context
{
    //Herdando DbContext
    public class DataContex : DbContext
    {
        //Construtor enviando para o DbContext a string de conexão
        public DataContex()
            : base(nameOrConnectionString: ConfigurationManager.ConnectionStrings["banco"].ConnectionString)
        {

        }

        //Sobrescrevendo OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //adicionando as classes de mapeamento
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PerfilMap());
        }

        //Declarando DbSet para cada Entidade
        public DbSet<Usuario> Usuario {get; set;}
        public DbSet<Perfil> Perfil { get; set; }
    }
}
