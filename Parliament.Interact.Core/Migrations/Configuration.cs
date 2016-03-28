using System.Collections.Generic;
using System.ComponentModel;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
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
                new ActionItem { ViewName = ActionViewName.ContactYourMP},
                new ActionItem { ViewName = ActionViewName.Links },
                new ActionItem { ViewName = ActionViewName.Petitions }
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
                        ActionItems = actionItems.WhereToList(x => x.ViewName == ActionViewName.ContactYourMP)
                    },
                    new Issue
                    {
                        Title = "Investigatory Powers",
                        Description = "Description of Test Issue 3",
                        ActionItems = actionItems.WhereToList(x => x.ViewName == ActionViewName.ContactYourMP)
                    }, new Issue
                    {
                        Title = "Academy Schools",
                        Description = "Description of Test Issue 4",
                        ActionItems = actionItems.WhereToList(x => x.ViewName == ActionViewName.ContactYourMP)
                    }, new Issue
                    {
                        Title = "Housing & Planning",
                        Description = "Description of Test Issue 5",
                        ActionItems = actionItems.WhereToList(x => x.ViewName == ActionViewName.ContactYourMP)
                    });
        }
    }
}
