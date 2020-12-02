namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2703b589-6f67-459c-853a-d84b13ec5050', N'oybek.abdullaev.2000@mail.ru', 0, N'APgrUZHKJH5Gr9bOw73AManczjTQAJSqAxN1kFuQ/H2bWlutA4ZkKkl5p6gZtAxObw==', N'eeb5386f-d3d3-43c6-9c1b-ccb20e465b9b', NULL, 0, 0, NULL, 1, 0, N'oybek.abdullaev.2000@mail.ru')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'83713b1d-e043-450e-8fb4-d5680164118f', N'oybek.abdullaev.4801@gmail.com', 0, N'AOMJu6yvgzqLcdeyDlYvhICj4Ij8xv/9EH2kTwHO7ifevRBNhqV6A3ShGBK90J8BfQ==', N'55d7495c-9c2c-4817-8ec2-04c90bd9d64d', NULL, 0, 0, NULL, 1, 0, N'oybek.abdullaev.4801@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'29b508ba-6f54-4122-ac2e-08ff46b7184c', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'83713b1d-e043-450e-8fb4-d5680164118f', N'29b508ba-6f54-4122-ac2e-08ff46b7184c')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
