namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTblOSList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperatingSystem = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OS");
        }
    }
}
