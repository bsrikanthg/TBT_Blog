namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'0c829dfe-b085-4a49-858f-63957526b2e3', N'adminUM@web.in', 0, N'AOOBzxcDoJpy8HXk7dXsKlCnE63rmmn7syrR/kAtk6aSS5V+tg5zoscXIsfCQsbGhg==', N'aa1186cf-0006-4e74-884a-8468ceef839a', NULL, 0, 0, NULL, 0, 0, N'adminUM@web.in', N'DSDSD')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0c829dfe-b085-4a49-858f-63957526b2e3', N'ae8b28a0-8a19-4686-b234-0c26b58e7a07')");
        }
        
        public override void Down()
        {
        }
    }
}
