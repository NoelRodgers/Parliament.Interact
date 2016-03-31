using System.Collections.Generic;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;
using System.Data.Entity.Migrations;
using System.IO;
using System.Web;
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
            context.ActionContents.RemoveRange(context.ActionContents);
            context.IssueActionContents.RemoveRange(context.IssueActionContents);
            context.IssueTimeLines.RemoveRange(context.IssueTimeLines);
            context.FurtherReadings.RemoveRange(context.FurtherReadings);
            context.IssueActions.RemoveRange(context.IssueActions);
            context.ActionItems.RemoveRange(context.ActionItems);
            context.Issues.RemoveRange(context.Issues);
            context.FurtherReadings.RemoveRange(context.FurtherReadings);
            context.IssueTimeLines.RemoveRange(context.IssueTimeLines);

            var actionItems = new List<ActionItem>
            {
                new ActionItem {ViewName = ActionViewName.ContactYourMP, ActionContents = new List<ActionContent>()
                {
                    new ActionContent()
                    {
                        Key = "Title",
                        Content = "Contact your MP"
                    },
                    new ActionContent()
                    {
                        Key = "Eta",
                        Content = "Approx 15mins"
                    },
                    new ActionContent()
                    {
                        Key = "BasicContent",
                        Content = "<p>Write to your MP about academy schools. Your MP represents you. They can raise your concerns in Parliament and question Government.</p>"
                    }
                }  },
                new ActionItem {ViewName = ActionViewName.Links, ActionContents = new List<ActionContent>()
                {
                    new ActionContent()
                    {
                        Key = "Title",
                        Content = "Links"
                    },
                    new ActionContent()
                    {
                        Key = "Eta",
                        Content = "10 minutes"
                    },
                    new ActionContent()
                    {
                        Key = "BasicContent",
                        Content = "Basic Content for Links"
                    }
                }},
                new ActionItem {ViewName = ActionViewName.Petitions, ActionContents = new List<ActionContent>()
                {
                    new ActionContent()
                    {
                        Key = "Title",
                        Content = "Sign or start a petition"
                    },
                    new ActionContent()
                    {
                        Key = "Eta",
                        Content = "Approx 5mins"
                    },
                    new ActionContent()
                    {
                        Key = "BasicContent",
                        Content = "<p>Sign or Start a petition about academy schools. The Government must respond to petitions that get 10,000 signatures. A petition that receives 100,000 signatures may be debated in Parliament.</p>"
                    }
                }}
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
                    LogicalOrder = 2,
                    Content = "Description of Test Issue 1",
                },
                new Issue
                {
                    Title = "Refugees & Asylum",
                    LogicalOrder = 3,
                    Content = "Description of Test Issue 2"
                },
                new Issue
                {
                    Title = "Investigatory Powers",
                    LogicalOrder = 4,
                    Content = "Description of Test Issue 3"
                },
                new Issue
                {
                    Title = "Housing & Planning",
                    LogicalOrder = 5,
                    Content = "Description of Test Issue 5"
                },
                new Issue
                {
                    Title = "Academy Schools",
                    LogicalOrder = 1,
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
                    Issue = issues[4],
                    ActionItem = actionItems[1],
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "Title",
                            Content = "Visit the parliament website"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content = "http://www.parliament.uk"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Parliament Website"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "10 minutes"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content = "Example of basic content"
                        }
                    }
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
                    ActionItem = actionItems[2]
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
