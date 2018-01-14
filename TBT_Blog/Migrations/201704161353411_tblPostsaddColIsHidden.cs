namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPostsaddColIsHidden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsHidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "HideReason", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "HideReason");
            DropColumn("dbo.Posts", "IsHidden");
        }
    }
}
