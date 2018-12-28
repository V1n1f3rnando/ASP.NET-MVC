using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using AutenticaUsuario.Entidades;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticaUsuario.Repositorio.Maps
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //Tabela
            ToTable("Usuario");

            //Chave
            HasKey(u => u.IdUsuario);

            //Propriedades
            Property(u => u.IdUsuario).HasColumnName("IdUsuario");

            Property(u => u.Nome).HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.Login).HasColumnName("Login")
                .HasMaxLength(25)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("ix_login")
                {IsUnique = true }));

            Property(u => u.Senha).HasColumnName("Senha")
                .HasMaxLength(50)
                .IsRequired();

            //Entidade associativa 
            // n:n

            HasMany(u => u.Perfil) //Usuário tem muitos perfis
                .WithMany(p => p.Usuario)//Perfil tem muitos usuários
                .Map(m =>
                {
                    m.ToTable("UsuarioPerfil"); //Nome da tabela associativa
                    m.MapLeftKey("IdUsuario"); // Chave estrangeira de Usuario
                    m.MapRightKey("IdPerfil"); // Chave estrangeira de Perfil 
                });
 
        }
    }
}
