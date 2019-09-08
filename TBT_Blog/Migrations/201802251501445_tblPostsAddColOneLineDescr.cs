namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPostsAddColOneLineDescr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "OneLineDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "OneLineDescription");
        }
    }
}
