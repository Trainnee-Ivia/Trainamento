using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Services
{
    public class MenuDb
    {
        private List<Menu> _menusDoPerfil;
        //private IRepository<Menu> _menuRepository;

        public MenuDb(List<Menu> menusDoPerfil)
        {
            this._menusDoPerfil = menusDoPerfil;
            //_menuRepository = menuRepository;
        }

        public List<Menu> Load()
        {

            var menus = LoadMenu(_menusDoPerfil).ToList();

            return menus;
        }

        private List<Menu> LoadMenu(List<Menu> menus)
        {
            List<Menu> menuRaiz = new List<Menu>();

            menus = menus.OrderBy(x => x.DisplayOrder).ToList();
            foreach (var item in menus)
            {
                if(item.ParentId != 0)
                {
                    menus.Single(x => x.Id == item.ParentId).Menus.Add(item);
                }else
                {
                    menuRaiz.Add(item);
                }
            }
            return menuRaiz;
        }

    }
}
