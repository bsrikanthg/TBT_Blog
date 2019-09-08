namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblCategorytblPostsAddColCategory2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CategoryId", c => c.Int(nullable: false, defaultValue:2));
            CreateIndex("dbo.Posts", "CategoryId");
            AddForeignKey("dbo.Posts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropColumn("dbo.Posts", "CategoryId");
        }
    }
}
