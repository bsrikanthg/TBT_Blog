namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPostAddAuthIdFk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "PostId", "dbo.Posts");
            DropIndex("dbo.Authors", new[] { "PostId" });
            DropColumn("dbo.Authors", "PostId");
            DropColumn("dbo.Posts", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "AuthorId", c => c.String(nullable: false));
            AddColumn("dbo.Authors", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Authors", "PostId");
            AddForeignKey("dbo.Authors", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
