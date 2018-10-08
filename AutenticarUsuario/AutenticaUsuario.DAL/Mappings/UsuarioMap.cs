using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutenticaUsuario.Entidades;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutenticaUsuario.DAL.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            //nome da tabela..
            ToTable("Usuario");

            //chave primaria
            HasKey(u => u.IdUsuario);

            //demais propriedades..

            Property(u => u.IdUsuario)
            .HasColumnName("IdUsuario");

            Property(u => u.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(50)
            .IsRequired();

            Property(u => u.Login)
            .HasColumnName("Login")
            .HasMaxLength(25)
            .IsRequired()
            .HasColumnAnnotation(IndexAnnotation.AnnotationName,
            new IndexAnnotation(new IndexAttribute("ix_login")
            { IsUnique = true }));

            Property(u => u.Senha)
            .HasColumnName("Senha")
            .HasMaxLength(50)
            .IsRequired();

            //Muitos para muitos -> Será criado uma entidade associativa,
            //ou seja, uma tabela contendo somente
            //os ids do usuario e do perfil..
            HasMany(u => u.Perfis) //Usuario TEM Muitos Perfis
            .WithMany(p => p.Usuario) //Perfil TEM Muitos Usuarios
            .Map(m =>
            {
                m.ToTable("UsuarioPerfil"); //nome da tabela associativa
                m.MapLeftKey("IdUsuario"); //foreign key do Usuario
                m.MapRightKey("IdPerfil"); //foreign key do perfil
            });
        }
    }
}
