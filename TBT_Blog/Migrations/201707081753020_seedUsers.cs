namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1a8cf9e1-7e63-4835-8a91-c1ab32921eda', N'admin1@me.in', 0, N'ACgjSngDY2mHYtNxNdmDQzrjoxvwQ3+HLeCtULMrCZ7dPTmdEaDh29UWttqqorQIgQ==', N'8d50b0cd-8033-448e-a0dd-80448b0d7be3', NULL, 0, 0, NULL, 0, 0, N'admin1@me.in')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'95b0124e-13a6-4d0d-98e5-bfa7ac8a6eba', N'b.srikanth.bmbs@gmail.com', 0, N'AEF7YW748caqvF3U3IznjXss6IGbV9cCgILfO0GdMZXF5WuNplwvQ9Fv/4hHAoASaA==', N'3ca61a4c-9499-45c0-a4e7-8f56a0e5db2e', NULL, 0, 0, NULL, 0, 0, N'b.srikanth.bmbs@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de9ab804-5329-4016-b064-e1b96ba08e71', N'guest@me.in', 0, N'AH8wbr2PR0ANRsBX5dSOvYtLbW6E8fV9Vj6ga2nAQweWuW9KPb34THfZLpQL21eq0Q==', N'b0126599-3e78-4689-a3e3-551d052c6e0a', NULL, 0, 0, NULL, 0, 0, N'guest@me.in')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ae8b28a0-8a19-4686-b234-0c26b58e7a07', N'CanManagePosts')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1a8cf9e1-7e63-4835-8a91-c1ab32921eda', N'ae8b28a0-8a19-4686-b234-0c26b58e7a07')

");
        }
        
        public override void Down()
        {
        }
    }
}
