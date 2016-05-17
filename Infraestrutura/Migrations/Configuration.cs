namespace Infraestrutura.Migrations
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infraestrutura.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Infraestrutura.Contexto context)
        {
            Menu[] listaMenus = new Menu[]
            {
                new Menu() { Nome = "Administração", ParentId = 0, Action = "", DisplayOrder = 1 },
                    new Menu() { Nome = "Perfis", ParentId = 1, Action = "/Administracao/Perfis/", DisplayOrder = 101 },
                    new Menu() { Nome = "Usuarios", ParentId = 1, Action = "/Administracao/Usuarios/", DisplayOrder = 102 },
                        new Menu() { Nome = "Cadastrar", ParentId = 3, Action = "/Usuarios/Cadastrar/", DisplayOrder = 10201 },
                    new Menu() { Nome = "Funcionarios", ParentId = 1, Action = "/Administracao/Funcionarios", DisplayOrder = 103 },
                new Menu() { Nome = "Clientes", ParentId = 0, Action = "/Clientes/Index", DisplayOrder = 2 }
            };

            Usuario adminUser = new Usuario()
            {
                Nome = "Administrador",
                User = "admin",
                Senha = new Senha("123").senhacrypto,
                Email = "admin@email.com",
                PerfilId = 1,
                SedeId = 1
            };

            Usuario gerUser = new Usuario()
            {
                Nome = "Gerente",
                User = "ger",
                Senha = new Senha("123").senhacrypto,
                Email = "ger@email.com",
                PerfilId = 2,
                SedeId = 1
            };

            //context.Menus.AddOrUpdate(listaMenus);


            context.Perfis.AddOrUpdate(
                new Perfil() {
                    Nome = "Administrador",
                    Descricao = "Administrador do site",
                    Reader = true, Writer = true,
                    Menus = listaMenus,
                    Usuarios = new List<Usuario>() {
                        adminUser
                    }},
                new Perfil()
                {
                    Nome = "Gerente",
                    Descricao = "Gerente de Compras",
                    Reader = true,
                    Writer = false,
                    Menus = new Menu[] { listaMenus[0], listaMenus[4], listaMenus[5] },
                    Usuarios = new List<Usuario>() {
                        gerUser
                    }
                }
            );

            context.Sedes.AddOrUpdate(
                new Sede() { Nome = "Fortaleza" },
                new Sede() { Nome = "Natal" },
                new Sede() { Nome = "Recife" }
            );

            


        }
    }
}
