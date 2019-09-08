namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblAddTblWebsiteExceptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebsiteExceptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source = c.String(),
                        Message = c.String(),
                        InnerException = c.String(),
                        TargetSite = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebsiteExceptions");
        }
    }
}
