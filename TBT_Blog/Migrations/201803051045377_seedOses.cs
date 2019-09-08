namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedOses : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[OS] ON
INSERT INTO [dbo].[OS] ([Id], [OperatingSystem]) VALUES (1, N'Windows')
INSERT INTO [dbo].[OS] ([Id], [OperatingSystem]) VALUES (2, N'Android')
INSERT INTO [dbo].[OS] ([Id], [OperatingSystem]) VALUES (3, N'iOS')
INSERT INTO [dbo].[OS] ([Id], [OperatingSystem]) VALUES (4, N'Linux')
SET IDENTITY_INSERT [dbo].[OS] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
