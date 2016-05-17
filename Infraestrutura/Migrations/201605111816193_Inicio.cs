namespace Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 20, unicode: false),
                        Action = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        isWriter = c.Boolean(nullable: false),
                        isReader = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        SedeId = c.Int(nullable: false),
                        User = c.String(),
                        Senha = c.String(nullable: false, maxLength: 32, fixedLength: true, unicode: false),
                        Email = c.String(nullable: false, maxLength: 80, fixedLength: true, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil", t => t.PerfilId, cascadeDelete: true)
                .ForeignKey("dbo.Sede", t => t.SedeId, cascadeDelete: true)
                .Index(t => t.PerfilId)
                .Index(t => t.SedeId);
            
            CreateTable(
                "dbo.Sede",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerfilMenu",
                c => new
                    {
                        MenuId = c.Int(nullable: false),
                        PerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuId, t.PerfilId })
                .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.MenuId)
                .Index(t => t.PerfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PerfilMenu", "PerfilId", "dbo.Perfil");
            DropForeignKey("dbo.PerfilMenu", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Usuario", "SedeId", "dbo.Sede");
            DropForeignKey("dbo.Usuario", "PerfilId", "dbo.Perfil");
            DropIndex("dbo.PerfilMenu", new[] { "PerfilId" });
            DropIndex("dbo.PerfilMenu", new[] { "MenuId" });
            DropIndex("dbo.Usuario", new[] { "SedeId" });
            DropIndex("dbo.Usuario", new[] { "PerfilId" });
            DropTable("dbo.PerfilMenu");
            DropTable("dbo.Sede");
            DropTable("dbo.Usuario");
            DropTable("dbo.Perfil");
            DropTable("dbo.Menu");
        }
    }
}
