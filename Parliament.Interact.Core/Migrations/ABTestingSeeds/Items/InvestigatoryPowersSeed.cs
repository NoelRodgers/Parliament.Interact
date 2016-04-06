using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.Domain.Context;

namespace Parliament.Interact.Core.Migrations.ABTestingSeeds.Items
{
    public class InvestigatoryPowersSeed : IABTestingItem
    {
        public string ConfigurationName { get { return "InvestigatoryPowers"; } }
        public void Seed(InteractDbContext context)
        {
            var issueContentForInvestigatoryPowers = new StringBuilder();
            issueContentForInvestigatoryPowers.Append("<p>The Home Office introduced the Investigatory Powers Bill on 1 March 2016. The Bill covers changes to the operation and regulation of the investigatory powers used by the police and the intelligence and security agencies.</p>");
            issueContentForInvestigatoryPowers.Append("<p>The Bill’s aims include bringing together current legislation on the interception, retention and use of communications data and create a single body for overseeing warrants to investigatory services led by an Investigatory Powers Commissioner.</p>");
            issueContentForInvestigatoryPowers.Append("<p>One potential change in the Bill would affect what communications data Police or other agencies could access. Currently Police or other agencies can access communications data such as historic phone bills; the proposed new legislation could allow them to ask firms to hold and share with them more information, such as which online services have been used by an individual.</p>");
            issueContentForInvestigatoryPowers.Append("<p>There are currently debates and discussions taking place in and outside of Parliament about the arguments for and against the proposed changes in the Bill. </p>");
            var actionItems = new List<ActionItem>
            {
                new ActionItem {ViewName = ActionViewName.ContactYourMP, ActionContents = new List<ActionContent>()
                {
                    new ActionContent
                    {
                        Key = "Title",
                        Content = "Contact your MP"
                    },
                    new ActionContent
                    {
                        Key = "Eta",
                        Content = "Approx 15mins"
                    },
                    new ActionContent
                    {
                        Key = "BasicContent",
                        Content = "<p>Write to your MP about academy schools. Your MP represents you. They can raise your concerns in Parliament and question Government.</p>"
                    }
                }  },
                new ActionItem {ViewName = ActionViewName.Links, ActionContents = new List<ActionContent>
                {
                    new ActionContent
                    {
                        Key = "Title",
                        Content = "Links"
                    },
                    new ActionContent
                    {
                        Key = "Eta",
                        Content = "10 minutes"
                    },
                    new ActionContent
                    {
                        Key = "BasicContent",
                        Content = "Basic Content for Links"
                    }
                }},
                new ActionItem {ViewName = ActionViewName.Petitions, ActionContents = new List<ActionContent>
                {
                    new ActionContent
                    {
                        Key = "Title",
                        Content = "Sign or start a petition"
                    },
                    new ActionContent
                    {
                        Key = "Eta",
                        Content = "Approx 5mins"
                    },
                    new ActionContent
                    {
                        Key = "BasicContent",
                        Content = "<p>Sign or Start a petition about academy schools. The Government must respond to petitions that get 10,000 signatures. A petition that receives 100,000 signatures may be debated in Parliament.</p>"
                    }
                }},
                new ActionItem
                {
                    ViewName = ActionViewName.Social, ActionContents = new List<ActionContent>
                    {
                        new ActionContent
                        {
                            Key = "Title",
                            Content = "Help raise awareness",
                        },
                        new ActionContent
                        {
                            Key = "Eta",
                            Content = "Approx 2mins",
                        },
                        new ActionContent
                        {
                            Key = "BasicContent",
                            Content = "<p>Share this page about Academy Schools with your social network, friends, family and colleagues to get more people involved in this issue.</p>",
                        },
                    }
                }
            };

            var timelinesForInvestigatoryPowers = new List<IssueTimeLine>
            {
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Past,
                    HTMLContent = "<p>In November 2015 Government introduced the a draft version of the Investigatory Powers Bill so it could be considered by Parliament and potentially become law. A small group of MPs and peers were part of a committee which discussed this draft version of the Bill and heard from experts and the public and made recommendations for changes. In March 2016 the Home Office then introduced a new version of the Investigatory Powers Bill alongside written responses to the reports and scrutiny that had taken place so far.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Present,
                    HTMLContent = "<p>A committee of MPs is now in the process of looking at the Bill again in detail, and is currently collecting evidence from people who are interested.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Future,
                    HTMLContent = "<p>The committee may suggest changes to the Bill based on their findings. The Bill will then be debated in the House of Commons, followed by the House of Lords where further changes may be made. The House of Commons and the House of Lords will have to agree on a final version before it can become law.</p>"
                }
            };

            var furtherReadingsForInvestigatoryPowers = new List<IssueFurtherReading>
            {
                new IssueFurtherReading
                {
                    LinkName = "UK surveillance powers explained",
                    LinkUrl = "http://www.bbc.co.uk/news/uk-34713435",
                    Description = "BBC overview of the Bill",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "Investigatory Powers Bill stages",
                    LinkUrl = "http://services.parliament.uk/bills/2015-16/investigatorypowers.html",
                    Description = "Follow the Bill through Parliament",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "Investigatory Powers Bill",
                    LinkUrl = "http://www.publications.parliament.uk/pa/bills/cbill/2015-2016/0143/cbill_2015-20160143_en_1.htm",
                    Description = "Read the Bill",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "Investigatory Powers Will Library Briefing Paper",
                    LinkUrl = "http://researchbriefings.parliament.uk/ResearchBriefing/Summary/CBP-7518",
                    Description = "Read Library Briefing Paper",
                    DisplayExternalIcon = true
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
                    Title = "Investigatory Powers",
                    LogicalOrder = 2,
                    Content = issueContentForInvestigatoryPowers.ToString(),
                    TimeLines = timelinesForInvestigatoryPowers,
                    FurtherReadings = furtherReadingsForInvestigatoryPowers,
                    Image = dbImage,
                    ImageType = dbImageType
                }
            };

            var issueActions = new List<IssueAction>
            {
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[1],
                    IsPrimary = true,
                    LogicalOrder = 1,
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "Title",
                            Content = "Contribute to the inquiry"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content = "http://www.parliament.uk/business/news/2016/march/have-your-say-on-the-investigatory-powers-bill/"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Submit Evidence"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "Over 1hr"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content = "<p>Give your view on the Investigatory Powers Bill to the House of Commons Public Bill Committee. The Committee can use information you provide to help it question Ministers or make recommendations to Government.</p><p><strong>Submission deadline: Thursday 5 May 2016</strong></p>"
                        }
                    }
                },
                 new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[1],
                    IsPrimary = true,
                    LogicalOrder = 2,
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "Title",
                            Content = "Watch debates"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content = "http://parliamentlive.tv/Search?Keywords=Investigatory+powers+bill&Member=&MemberId=&House=&Business=&Start=22%2F02%2F2016&End=22%2F03%2F2016"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Watch a debate"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "Over 30mins"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content = "<p>Watch the most recent debates on this issue from Parliament online with Parliamentlive.tv, a free service from Parliament streaming live and archive coverage of all UK Parliament proceedings taking place in public, including debates and committee meetings.</p>"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[2],
                    IsPrimary = true,
                    LogicalOrder = 2,
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content = "<p>Sign or start a petition about this issue. The Government must respond to petitions that get 10,000 signatures. A petition that receives 100,000 signatures may be debated in Parliament.</p>"
                        },
                        new IssueActionContent
                        {
                            Key = "Keywords",
                            Content = "Investigatory Powers"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[0],
                    IsPrimary = false,
                    LogicalOrder = 3
                },
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[3],
                    IsPrimary = true,
                    LogicalOrder = 5
                },
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[1],
                    IsPrimary = false,
                    LogicalOrder = 4,
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "Title",
                            Content = "Book a community group workshop"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content = "http://www.parliament.uk/get-involved/attend-an-event/events-for-organisations/"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Book a workshop"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "Approx 10mins"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content = "<p>If you are part of a group who may be affected by this issue and would like to understand more about the stages of the Bill and how and when you can get invovled, book a workshop from Parliament.</p>"
                        }
                    }
                },
            };

            context.Issues.AddOrUpdate(issues.ToArray());
            context.ActionItems.AddOrUpdate(actionItems.ToArray());
            context.IssueActions.AddOrUpdate(issueActions.ToArray());
        }
    }
}