namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPostModDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Posts", "DeletedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "DeletedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "ModifiedOn", c => c.DateTime(nullable: false));
        }
    }
}
