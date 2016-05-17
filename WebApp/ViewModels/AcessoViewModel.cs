using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebApp.ViewModels
{
    public class AcessoViewModel
    {
        [Required(ErrorMessage = "Informe o usuário")]
        public string User { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }
        public string Sede { get; set; }
        public List<SelectListItem> Sedes { get; set; }
        public Usuario Usuario{ get; set; }

        public AcessoViewModel()
        {
            Sedes = new List<SelectListItem>();
        }
    }
}
