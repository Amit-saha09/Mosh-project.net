namespace DvdCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1be3e1ef-0efc-4980-8ebd-22972cb7a2f8', N'admin@dvdcenter.com', 0, N'ALtWRZORrvud8THT1zG0Upe6c/0RnwcI6jJyKvJMlv8BW9zBFxPnfTffH0+prjZUig==', N'05b3812b-57d4-44f9-8fbf-39ce65edebdb', NULL, 0, 0, NULL, 1, 0, N'admin@dvdcenter.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'72d6d729-43ea-4a20-87c7-5c06ad7d04b2', N'admin1@dvdcenter.com', 0, N'AEDgoXn0Q9+g1HqxWeHePm4SFx7bkHgX1HhB3AcZPC2/ZOjCEJfQEqratZoWkALPuQ==', N'199c19e7-2f20-485b-b8c5-38d61fcdca24', NULL, 0, 0, NULL, 1, 0, N'admin1@dvdcenter.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ab4820e0-1fe5-4c3e-a993-55cf3cb0a611', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'72d6d729-43ea-4a20-87c7-5c06ad7d04b2', N'ab4820e0-1fe5-4c3e-a993-55cf3cb0a611')
");
        }
        
        public override void Down()
        {
        }
    }
}
