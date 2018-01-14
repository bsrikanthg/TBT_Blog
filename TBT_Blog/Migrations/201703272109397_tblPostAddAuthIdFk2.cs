namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPostAddAuthIdFk2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "AuthorId");
            AddForeignKey("dbo.Posts", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropColumn("dbo.Posts", "AuthorId");
        }
    }
}
