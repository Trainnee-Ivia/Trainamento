using Core.Entities;
using Core.Interfaces.Repositories;
using Infraestrutura;
using Infraestrutura.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AcessoController : Controller
    {
        //private Contexto _ctx;
        private IUnitOfWork uow;

        public AcessoController(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        // GET: Acesso
        [AllowAnonymous]
        public ActionResult Login()
        {
            AcessoViewModel infoLogin = new AcessoViewModel();

            CarregarSedes(infoLogin);
            
            return View(infoLogin);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(AcessoViewModel infoLogin)
        {
            if (!ModelState.IsValid)
            {
                CarregarSedes(infoLogin);
                return View(infoLogin);
            }

            LoginService loginService = new LoginService(uow.Usuarios);
            bool isLogado = loginService.isLogado(infoLogin.User, infoLogin.Senha);

            if (isLogado)
            {
                AdicionarAutorizacao(infoLogin);
                return RedirectToAction("Index", "Home");
            }

            CarregarSedes(infoLogin);
            ModelState.AddModelError("", "Usuario ou Senha inválidos");
            return View(infoLogin);
        }

        private void AdicionarAutorizacao(AcessoViewModel infoLogin)
        {
            var usuario = uow.Usuarios.GetSingle(infoLogin.User);
            List<Menu> menus = new MenuDb(uow.Perfis.GetSingle(usuario.PerfilId).Menus.ToList()).Load();
            Session["menus"] = menus;

            Claim[] claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Ivia Identity"),
                    new Claim(ClaimTypes.Name, usuario.Nome)
                };
            ClaimsIdentity identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(identity);
        }

        #region Helpers
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        #endregion

        private void CarregarSedes(AcessoViewModel infoLogin)
        {
            var sedes = uow.Sedes.GetAll();

            infoLogin.Sedes.Add(new SelectListItem { Value = "0", Text = "Selecione a sede...", Selected = true });
            infoLogin.Sedes.AddRange(sedes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Nome }));
        }
    }
}