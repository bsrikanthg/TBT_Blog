namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblCategorytblPostsAddColCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryOS = c.String(),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            Sql(@"SET IDENTITY_INSERT [dbo].[Categories] ON
INSERT INTO [dbo].[Categories] ([Id], [CategoryName], [CategoryOS], [CategoryDescription]) VALUES (1, N'Recovery Software', N'Windows', N'Repair and recovery software for windows.')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName], [CategoryOS], [CategoryDescription]) VALUES (2, N'Text Editors', N'Windows', N'Text editor')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName], [CategoryOS], [CategoryDescription]) VALUES (3, N'Windows Maintainance', N'Windows', N'Software to keep the computer running efficiently.')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName], [CategoryOS], [CategoryDescription]) VALUES (4, N'Windows Drivers', N'Windows', N'Device driver for Windows.')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName], [CategoryOS], [CategoryDescription]) VALUES (5, N'Development Software', N'Windows', N'Code editors/development environment')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName], [CategoryOS], [CategoryDescription]) VALUES (6, N'Development Hardware', N'Windows', N'Code editors/development environment for hardware.')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName], [CategoryOS], [CategoryDescription]) VALUES (7, N'Antivirus', N'Windows', N'Program to protect PC agains harmful virus programs and malicious internet sites.')
INSERT INTO [dbo].[Categories] ([Id], [CategoryName], [CategoryOS], [CategoryDescription]) VALUES (8, N'Web browsers', N'Windows', N'Tool to browse the internet.')
SET IDENTITY_INSERT [dbo].[Categories] OFF
");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
