using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutenticaUsuario.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace AutenticaUsuario.DAL.Mappings
{
    public class PerfilMap :EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            //nome da tabela..
            ToTable("Perfil");

            //chave primária..
            HasKey(p => p.IdPerfil);

            //demais propriedaes..
            Property(p => p.IdPerfil)
            .HasColumnName("IdPerfil");

            Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(50)
            .IsRequired();


        }
    }
}
