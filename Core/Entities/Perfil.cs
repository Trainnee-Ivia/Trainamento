using System.Collections.Generic;

namespace Core.Entities
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Writer { get; set; }
        public bool Reader { get; set; }

        public ICollection<Usuario> Usuarios{ get; set; }
        public ICollection<Menu> Menus { get; set; }

        public Perfil()
        {
            Usuarios = new List<Usuario>();
            Menus = new List<Menu>();
        }
    }
}


