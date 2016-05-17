using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infraestrutura.Repositories
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(DbContext Context) : base(Context)
        {
        }

        public Perfil GetSingle(int id)
        {
            return Context.Set<Perfil>().Include(x => x.Menus).Single(x => x.Id == id);
        }
    }
}
