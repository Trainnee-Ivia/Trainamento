using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Services
{
    public class LoginService
    {
        private readonly IUsuarioRepository Usuarios;

        public LoginService(IUsuarioRepository usuarios)
        {
            this.Usuarios = usuarios;
        }

        public bool isLogado(string User, string Senha)
        {
            var usuario = Usuarios.GetSingle(User);
            var senhaEncryp = new Senha(Senha).senhacrypto;

            if(usuario != null && usuario.Senha == senhaEncryp)
            {
                return true;
            }

            return false;
        }
    }
}
