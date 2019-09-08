namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblPostColAddOsId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "OSId", c => c.Int(nullable: false, defaultValue:1));
            CreateIndex("dbo.Posts", "OSId");
            AddForeignKey("dbo.Posts", "OSId", "dbo.OS", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "OSId", "dbo.OS");
            DropIndex("dbo.Posts", new[] { "OSId" });
            DropColumn("dbo.Posts", "OSId");
        }
    }
}
