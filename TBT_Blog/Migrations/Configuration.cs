namespace TBT_Blog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TBT_Blog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TBT_Blog.Models.BlogConnnectionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TBT_Blog.Models.BlogConnnectionDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Authors] ON
INSERT INTO[dbo].[Authors]([Id], [Name], [Gender], [BirthDate], [Email], [Mobile], [Address1], [City], [Region], [PostalCode]) VALUES(1, N'B.Srikanth', N'Male', N'1989-11-11 00:00:00', N'b.srikanth.bmbs@gmail.com', N'8050100552', N'#58, Tech City Layout', N'Bengaluru', N'Karnataka', N'560100')
SET IDENTITY_INSERT[dbo].[Authors] OFF
");
        }
    }
}
