using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(u => u.Id);
            Property(u => u.Id).HasColumnName("Id").HasColumnType("int");

            Property(u => u.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(50).IsRequired();

            Property(u => u.Senha).HasColumnName("Senha").HasColumnType("char").HasMaxLength(32).IsRequired();

            Property(u => u.Email).HasColumnName("Email").HasColumnType("char").HasMaxLength(80).IsRequired();

            HasRequired(u => u.Perfil).WithMany(u => u.Usuarios).HasForeignKey(u => u.PerfilId);

            HasRequired(u => u.Sede).WithMany(u => u.Usuarios).HasForeignKey(u => u.SedeId);

        }
    }
}
