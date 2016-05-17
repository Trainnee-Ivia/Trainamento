using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Infraestrutura.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private bool _disposed;
        private readonly Contexto Context;

        public IRepository<Menu> Menus { get { return new Repository<Menu>(Context); } }
        public IPerfilRepository Perfis { get { return new PerfilRepository(Context); } }
        public IRepository<Sede> Sedes { get { return new Repository<Sede>(Context); } }
        public IUsuarioRepository Usuarios { get { return new UsuarioRepository(Context); } }

        public UnitOfWork(Contexto context)
        {
            this.Context = context;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
