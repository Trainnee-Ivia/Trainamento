using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        Perfil GetSingle(int id);
    }
}
