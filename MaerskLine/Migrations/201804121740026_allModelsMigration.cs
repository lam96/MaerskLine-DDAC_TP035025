namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allModelsMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        BookedAgent = c.String(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        ShipId = c.Int(nullable: false),
                        ScheduleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleId, cascadeDelete: true)
                .ForeignKey("dbo.Ships", t => t.ShipId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ShipId)
                .Index(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 60),
                        MobilePhoneNumber = c.String(nullable: false),
                        RegisteredBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.RegisteredBy_Id)
                .Index(t => t.RegisteredBy_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Origin = c.String(nullable: false, maxLength: 30),
                        DepartTime = c.DateTime(nullable: false),
                        Destination = c.String(nullable: false, maxLength: 30),
                        ArriveTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        ShipId = c.Int(nullable: false, identity: true),
                        ShipName = c.String(nullable: false, maxLength: 255),
                        ShipContainerNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShipId);
            
            CreateTable(
                "dbo.Containers",
                c => new
                    {
                        ContainerId = c.Int(nullable: false, identity: true),
                        ItemsType = c.String(nullable: false),
                        WeightInTonne = c.Int(nullable: false),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContainerId)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Containers", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "ShipId", "dbo.Ships");
            DropForeignKey("dbo.Bookings", "ScheduleId", "dbo.Schedules");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "RegisteredBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Containers", new[] { "BookingId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Customers", new[] { "RegisteredBy_Id" });
            DropIndex("dbo.Bookings", new[] { "ScheduleId" });
            DropIndex("dbo.Bookings", new[] { "ShipId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Containers");
            DropTable("dbo.Ships");
            DropTable("dbo.Schedules");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
