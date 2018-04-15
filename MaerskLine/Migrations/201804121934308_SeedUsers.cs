namespace MaerskLine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9846999a-c683-4bdf-a627-40ae0c518a4c', N'admin@maersk.com', 0, N'ALbJxo+vP09/XDy5iIfiEcqwmx+lQjbESpujt0/yrXRQSe9vOiyYZCTSiN6Gj+Zfew==', N'376c3a9a-85c1-49b2-bcf8-5dcac9fecb11', NULL, 0, 0, NULL, 1, 0, N'admin@maersk.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a2770a3a-2d4a-414d-a1a9-de28b5584a82', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9846999a-c683-4bdf-a627-40ae0c518a4c', N'a2770a3a-2d4a-414d-a1a9-de28b5584a82')
");
        }
        
        public override void Down()
        {
        }
    }
}
