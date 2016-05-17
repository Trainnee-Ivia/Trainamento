using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Menu> Menus { get; }
        IPerfilRepository Perfis{ get; }
        IRepository<Sede> Sedes { get; }
        IUsuarioRepository Usuarios { get; }

        void SaveChanges();
    }
}
