using System;
using System.Collections.Generic;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;
using System.Data.Entity.Migrations;
using System.IO;
using System.Reflection;
using System.Text;
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

            var issueContent = new StringBuilder();
            issueContent.Append(
                "<p>The Government announced in March 2016 that every primary and secondary state school become an academy. (George Osborne, <a href='http://www.publications.parliament.uk/pa/cm201516/cmhansrd/cm160316/debtext/160316-0001.htm#16031632000621'>Budget Statement, 16 March 2016 <i class='fa fa-external'></i></a>)</p>");
            issueContent.Append("<p>Academies are state schools, independent of local authority control. They are funded directly by central government rather than by local authorities. By 2015 almost 60% of state-funded secondary schools were academies, up from 6% at the start of 2010.</p>");
            issueContent.Append("<h5>Should state schools become independent of local authority control?</h5>");
            issueContent.Append("<p>Government argues that freedom from local authority control brings opportunities for innovation, better leadership and higher attainment and that academies have had a positive impact on other schools in their local area.</p>");
            issueContent.Append("<p>Others say that the freedoms afforded to academies, and their rapid expansion, have the potential to result in financial problems and lapses in standards. (House of Commons Library, <a href='http://www.parliament.uk/business/publications/research/key-issues-parliament-2015/education/academies-and-free-schools/'>Key Issues for the 2015 Parliament <i class='fa fa-external'></i></a>)</p>");
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
                    HTMLContent = "<p></p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Present,
                    HTMLContent = "<p></p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Future,
                    HTMLContent = "<p></p>"
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

            var filename = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var path = Uri.UnescapeDataString(filename.Path);
            var directory = Path.GetDirectoryName(path) + "\\Migrations\\school.jpg";
            var originalImage = System.Drawing.Image.FromFile(directory);
            var dbImageType = MimeMapping.GetMimeMapping(directory);
            byte[] dbImage;
    
            using (var ms = new MemoryStream())
            {
                originalImage.Save(ms, originalImage.RawFormat);
                dbImage = ms.ToArray();
            }

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
                    Content = issueContent.ToString(),
                    TimeLines = timelines,
                    FurtherReadings = furtherReadings,
                    Image = dbImage,
                    ImageType = dbImageType
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
