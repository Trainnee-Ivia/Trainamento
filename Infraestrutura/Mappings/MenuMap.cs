using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Mappings
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            ToTable("Menu");

            HasKey(m => m.Id);
            Property(m => m.Id).HasColumnName("Id").HasColumnType("int").IsRequired();

            Property(m => m.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(20).IsRequired();

            Property(m => m.ParentId).HasColumnName("ParentId").HasColumnType("int").IsRequired();

            Property(m => m.Action).HasColumnName("Action").HasColumnType("varchar").HasMaxLength(50).IsRequired();

            Property(m => m.DisplayOrder).HasColumnName("DisplayOrder").HasColumnType("int").IsRequired();

            HasMany(m => m.Perfis).WithMany(m => m.Menus).Map(mp => {
                mp.MapLeftKey("MenuId");
                mp.MapRightKey("PerfilId");
                mp.ToTable("PerfilMenu");
            });


        }

    }
}
