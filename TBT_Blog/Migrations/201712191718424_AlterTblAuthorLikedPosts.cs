namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTblAuthorLikedPosts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuthorLikedPosts", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.AuthorLikedPosts", "Post_Id", "dbo.Posts");
            DropIndex("dbo.AuthorLikedPosts", new[] { "Author_Id" });
            DropIndex("dbo.AuthorLikedPosts", new[] { "Post_Id" });
            AddColumn("dbo.AuthorLikedPosts", "DateLiked", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AuthorLikedPosts", "Author_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.AuthorLikedPosts", "Post_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.AuthorLikedPosts", "Author_Id");
            CreateIndex("dbo.AuthorLikedPosts", "Post_Id");
            AddForeignKey("dbo.AuthorLikedPosts", "Author_Id", "dbo.Authors", "Id", cascadeDelete: false);
            AddForeignKey("dbo.AuthorLikedPosts", "Post_Id", "dbo.Posts", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorLikedPosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.AuthorLikedPosts", "Author_Id", "dbo.Authors");
            DropIndex("dbo.AuthorLikedPosts", new[] { "Post_Id" });
            DropIndex("dbo.AuthorLikedPosts", new[] { "Author_Id" });
            AlterColumn("dbo.AuthorLikedPosts", "Post_Id", c => c.Int());
            AlterColumn("dbo.AuthorLikedPosts", "Author_Id", c => c.Int());
            DropColumn("dbo.AuthorLikedPosts", "DateLiked");
            CreateIndex("dbo.AuthorLikedPosts", "Post_Id");
            CreateIndex("dbo.AuthorLikedPosts", "Author_Id");
            AddForeignKey("dbo.AuthorLikedPosts", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.AuthorLikedPosts", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
