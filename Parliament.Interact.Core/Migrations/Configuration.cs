using System.Collections.Generic;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;
using System.Data.Entity.Migrations;
using Parliament.Interact.Core.Domain.Context;

namespace Parliament.Interact.Core.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<InteractDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InteractDbContext context)
        {
            context.IssueActions.RemoveRange(context.IssueActions);
            context.ActionItems.RemoveRange(context.ActionItems);
            context.Issues.RemoveRange(context.Issues);
            var actionItems = new List<ActionItem>
            {
                new ActionItem {ViewName = ActionViewName.ContactYourMP},
                new ActionItem {ViewName = ActionViewName.Links},
                new ActionItem {ViewName = ActionViewName.Petitions}
            };

            var issues = new List<Issue>
            {
                new Issue
                {
                    Title = "EU Referendum",
                    Content = "Description of Test Issue 1",
                },
                new Issue
                {
                    Title = "Refugees & Asylum",
                    Content = "Description of Test Issue 2"
                },
                new Issue
                {
                    Title = "Investigatory Powers",
                    Content = "Description of Test Issue 3"
                },
                new Issue
                {
                    Title = "Academy Schools",
                    Content = "Description of Test Issue 4"
                },
                new Issue
                {
                    Title = "Housing & Planning",
                    Content = "Description of Test Issue 5"
                }
            };

            var issueActions = new List<IssueAction>
            {
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[0]
                },
                new IssueAction
                {
                    Issue = issues[1],
                    ActionItem = actionItems[0]
                },
                new IssueAction
                {
                    Issue = issues[2],
                    ActionItem = actionItems[0]
                },
                new IssueAction
                {
                    Issue = issues[3],
                    ActionItem = actionItems[0]
                },
                new IssueAction
                {
                    Issue = issues[4],
                    ActionItem = actionItems[0]
                }
            };

            context.Issues.AddOrUpdate(issues.ToArray());
            context.ActionItems.AddOrUpdate(actionItems.ToArray());
            context.IssueActions.AddOrUpdate(issueActions.ToArray());
        }
    }
}
