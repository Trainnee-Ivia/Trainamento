using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Sede
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

        public Sede()
        {
            Usuarios = new List<Usuario>();
        }
    }
}
