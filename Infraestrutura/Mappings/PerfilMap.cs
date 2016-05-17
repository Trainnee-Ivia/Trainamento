using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mappings
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("Perfil");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("Id").HasColumnType("int").IsRequired();

            Property(p => p.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(100).IsOptional();
            
            Property(p => p.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(20).IsRequired();

            Property(p => p.Reader).HasColumnName("isReader").HasColumnType("bit").IsRequired();

            Property(p => p.Writer).HasColumnName("isWriter").HasColumnType("bit").IsRequired();
            
        }
    }
}
