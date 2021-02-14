namespace Movieship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5c8d92c3-fcda-471c-9489-d72fa2007bb9', N'guest@movieship.com', 0, N'ANK09ohWYqjlWtx8EIauuhPYqX8aKYK+AnmI3ObKZkqQ5QiW/j9SwvcAcgSMYOajoA==', N'bc00d8a3-185f-496f-9185-2d100e9ad556', NULL, 0, 0, NULL, 1, 0, N'guest@movieship.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dbafa2d2-d2d2-49ee-a15d-119098952161', N'admin@moviship.com', 0, N'AG6um8V6UakYCE3a3bEc6BeIl8TMeUnhBmb9dUhkSH85P7RBk6S1MoEQVSFcV4IJ9w==', N'2051dea2-86bc-4f63-ac53-6a59de71d3b8', NULL, 0, 0, NULL, 1, 0, N'admin@moviship.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7c51b84a-d7c6-4285-a67a-534f904aa1e9', N'CanManageCustomer')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dbafa2d2-d2d2-49ee-a15d-119098952161', N'7c51b84a-d7c6-4285-a67a-534f904aa1e9')

");
        }
        
        public override void Down()
        {
        }
    }
}
