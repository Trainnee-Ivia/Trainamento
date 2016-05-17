using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mappings
{
    public class SedeMap : EntityTypeConfiguration<Sede>
    {
        public SedeMap()
        {
            ToTable("Sede");

            HasKey(s => s.Id);
            Property(s => s.Id).HasColumnName("Id").HasColumnType("int");

            Property(s => s.Nome).IsRequired().HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(30);

        }
    }
}
