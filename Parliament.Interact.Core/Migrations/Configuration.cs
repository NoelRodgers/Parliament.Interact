using System.Collections.Generic;
using System.ComponentModel;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Parliament.Interact.Core.Domain.Context.InteractDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Parliament.Interact.Core.Domain.Context.InteractDbContext context)
        {
            context.ActionItems.RemoveRange(context.ActionItems);
            context.Issues.RemoveRange(context.Issues);
            List<ActionItem> actionItems = new List<ActionItem>
            {
                new ActionItem { Title = "Contact your MP" },
                new ActionItem { Title = "Create a petition" },
                new ActionItem { Title = "Visit a page" }
            };

            context.Issues.AddOrUpdate(
                   new Issue
                   {
                       Title = "EU Referendum",
                       Description = "Description of Test Issue 1",
                       ActionItems = actionItems
                   },
                    new Issue
                    {
                        Title = "Refugees & Asylum",
                        Description = "Description of Test Issue 2",
                        ActionItems = actionItems.WhereToList(x => x.Title == "Contact your MP")
                    },
                    new Issue
                    {
                        Title = "Investigatory Powers",
                        Description = "Description of Test Issue 3",
                        ActionItems = actionItems.WhereToList(x => x.Title == "Contact your MP")
                    }, new Issue
                    {
                        Title = "Academy Schools",
                        Description = "Description of Test Issue 4",
                        ActionItems = actionItems.WhereToList(x => x.Title == "Contact your MP")
                    }, new Issue
                    {
                        Title = "Housing & Planning",
                        Description = "Description of Test Issue 5",
                        ActionItems = actionItems.WhereToList(x => x.Title == "Contact your MP")
                    });
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
        }
    }
}
