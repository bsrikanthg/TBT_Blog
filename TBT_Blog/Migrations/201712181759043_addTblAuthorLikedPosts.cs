namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTblAuthorLikedPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorLikedPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorLikedPosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.AuthorLikedPosts", "Author_Id", "dbo.Authors");
            DropIndex("dbo.AuthorLikedPosts", new[] { "Post_Id" });
            DropIndex("dbo.AuthorLikedPosts", new[] { "Author_Id" });
            DropTable("dbo.AuthorLikedPosts");
        }
    }
}
