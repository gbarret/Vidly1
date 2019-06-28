namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5121ab9a-f48f-473c-8834-35de9a142171', N'gbarret@gmail.com', 0, N'AHeLmcf7nPni4HoF8Xh2ErAMcLhI/JN8b1cev7pQvTm2svibQmXhI9X0KHNXX7pj4g==', N'13e20503-8627-4ca7-8e57-442322dc9dad', NULL, 0, 0, NULL, 1, 0, N'gbarret@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'95ee3324-4231-469b-a68b-c55a6dea3972', N'guest@vidly.com', 0, N'AH/qeGLDPh3UgkMcBxNSScjzKZbxpxyqmXrQTy8H+Tm9TLpmWtYlqRUA3xwZ6rnZdA==', N'de8ffa29-59dc-4aa6-b825-cb1d83bf1435', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b34c07d9-5bdc-4a0b-98bd-296905ecbfce', N'admin@vidly.com', 0, N'ADl7KFoHTCjkwMbSRhK9pOo7AL6rXvipkPKPsM/37mHcBZL6WusEBGqb/D2fKdBrtw==', N'4a2daea7-3ffc-4369-a667-c0770fdf4327', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'94d889f0-f9dd-4bfc-8f26-a38723294b27', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b34c07d9-5bdc-4a0b-98bd-296905ecbfce', N'94d889f0-f9dd-4bfc-8f26-a38723294b27')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5121ab9a-f48f-473c-8834-35de9a142171', N'94d889f0-f9dd-4bfc-8f26-a38723294b27')


");

        }
        
        public override void Down()
        {
        }
    }
}
