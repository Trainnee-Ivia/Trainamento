using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using System.Data.Entity;

namespace Infraestrutura.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(Contexto context) : base(context)
        {
        }

        public Usuario GetSingle(string user)
        {
            return Context.Set<Usuario>().Include(x => x.Perfil).Include(x => x.Sede).Where(u => u.User == user).FirstOrDefault();
        }
        
    }
}
