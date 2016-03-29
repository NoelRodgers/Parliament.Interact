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
            context.FurtherReadings.RemoveRange(context.FurtherReadings);
            context.IssueTimeLines.RemoveRange(context.IssueTimeLines);

            var actionItems = new List<ActionItem>
            {
                new ActionItem {ViewName = ActionViewName.ContactYourMP},
                new ActionItem {ViewName = ActionViewName.Links},
                new ActionItem {ViewName = ActionViewName.Petitions}
            };

            var timelines = new List<IssueTimeLine>
            {
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Past,
                    HTMLContent = "<p>Debated last week in the House of Commons.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Present,
                    HTMLContent = "<p>Debating this week in the House of Commons.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Future,
                    HTMLContent = "<p>Debating next week in the House of Commons.</p>"
                }
            };

            var furtherReadings = new List<IssueFurtherReading>
            {
                new IssueFurtherReading
                {
                    LinkName = "link name 1",
                    LinkUrl = "###",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "link name 2",
                    LinkUrl = "###",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "link name 3",
                    LinkUrl = "###",
                    DisplayExternalIcon = false
                }
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
                    Title = "Housing & Planning",
                    Content = "Description of Test Issue 5"
                },
                new Issue
                {
                    Title = "Academy Schools",
                    Content = "<p>Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.</p>",
                    TimeLines = timelines,
                    FurtherReadings = furtherReadings
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
