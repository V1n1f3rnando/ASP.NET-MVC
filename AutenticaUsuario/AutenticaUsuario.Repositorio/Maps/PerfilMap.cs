using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using AutenticaUsuario.Entidades;

namespace AutenticaUsuario.Repositorio.Maps
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            //Nome da tabela
            ToTable("Perfil");

            //Chave primária
            HasKey(p => p.IdPerfil);

            //Propriedades
            Property(p => p.IdPerfil).HasColumnName("IdPerfil");

            Property(p => p.Nome).HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();


        }
    }
}
