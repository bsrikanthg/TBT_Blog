namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPostAddAuthId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "AuthorId", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "PostName", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String());
            AlterColumn("dbo.Posts", "PostName", c => c.String());
            DropColumn("dbo.Posts", "AuthorId");
        }
    }
}
