namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allModelsMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "RegisteredBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "RegisteredBy_Id" });
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "RegisteredBy_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "RegisteredBy_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Customers", "RegisteredBy_Id");
            AddForeignKey("dbo.Customers", "RegisteredBy_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
