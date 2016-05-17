using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Nome { get; set; }
        public string Action { get; set; }
        public int DisplayOrder { get; set; }

        public List<Menu> Menus { get; set; }
        public ICollection<Perfil> Perfis { get; set; }

        public Menu()
        {
            Perfis = new List<Perfil>();
            Menus = new List<Menu>();
        }
    }
}
