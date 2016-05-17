using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int SedeId { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }

        public virtual Sede Sede { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
