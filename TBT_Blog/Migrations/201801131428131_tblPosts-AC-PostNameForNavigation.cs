namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPostsACPostNameForNavigation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostNameForNavigation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostNameForNavigation");
        }
    }
}
