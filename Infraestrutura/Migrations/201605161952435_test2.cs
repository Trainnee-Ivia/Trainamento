namespace Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menu", "Menu_Id", c => c.Int());
            CreateIndex("dbo.Menu", "Menu_Id");
            AddForeignKey("dbo.Menu", "Menu_Id", "dbo.Menu", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menu", "Menu_Id", "dbo.Menu");
            DropIndex("dbo.Menu", new[] { "Menu_Id" });
            DropColumn("dbo.Menu", "Menu_Id");
        }
    }
}
