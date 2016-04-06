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
    public class RefugeesPowersSeed : IABTestingItem
    {
        public string ConfigurationName { get { return "Refugees"; } }
        public void Seed(InteractDbContext context)
        {
            var issueContentForRefugees = new StringBuilder();


            issueContentForRefugees.Append("<p>As the Government administers and develops the process for handling refugees in the UK, Members of the House of Commons and Peers in the House of Lords work to look at how well existing process are working and what the impact of proposed changes will be.</p>");
            issueContentForRefugees.Append("<p>The United Nations High Commission for Refugees (UNHCR) warned in 2015 that the world is in the midst of a forced migration crisis. It see the Syrian conflict as the biggest cause. Huge numbers of people are dying trying to cross the Mediterranean to Southern Europe from Libya. European Countries are struggling to deal with the numbers reaching their boarders, and securing agreement within the EU on a coordinated response is proving difficult.</p>");
            issueContentForRefugees.Append("<p>The total number of people applying for asylum in EU counties increased from a monthly average of 22, 000 in 2010 to 110, 000 in 2015. Asylum applications in EU countries reached their highest level in October 2015 at 172, 000, falling to 109, 000 in December 2015. The number of asylum applications to the UK peaked in 2002 at 84, 132.After that the number fell sharply to reach a twenty year low point of 17, 916 in 2010, before rising slowly to reach 32, 414 in 2015.</p>");
            issueContentForRefugees.Append("<p>The Government is planning to resettle up to 20,000 Syrian refugees in the UK by the end of this Parliament in 2020.</p>");
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

            var timelinesForRefugees = new List<IssueTimeLine>
            {
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Past,
                    HTMLContent = "<p>On 7 September 2015, the Prime Minister announced the UK is now planning to resettle up to 20,000 refugees from the Syrian region over the next five years. The Government also announced, on 28 January 2016, that it would work with the UN High Commissioner for Refugees(UNHCR) to lead a new initiative to resettle unaccompanied children from conflict regions.</p><p>On Wednesday 10 February 2016, three debates relating to migration were held by MPs.The topics include the provision of asylum support, migration into the EU, and the UK Government’s policy on refugees.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Present,
                    HTMLContent = "<p>The Immigration Bill, which changes the law on immigration and asylum, is being debated in Parliament. It will be looked at for the last time by the House of Lords on 12 April before the changes they have made are considered by the House of Commons.</p><p>Peers in the House of Lords recently voted in favour of a new clause to the Immigration Bill 2015 - 16, which would extend asylum seekers' rights to work. As a general rule, asylum seekers are not allowed to work in the UK.The clause did not have Government support.</p><p>The EU Home Affairs Sub - Committee launches a new inquiry into unaccompanied minors in the EU. Unaccompanied minors are migrant children below the age of 18 from non-EU countries who are not accompanied by a parent or customary guardian.The Committee will be questioning Ministers and making recommendations to Government.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Future,
                    HTMLContent = "<p>In the House of Lords on 11 April the Government will be asked about the nnumber of refugees who have died in the Mediterranean and Aegean Seas since January 2015.</p>"
                }
            };

            var furtherReadingsForRefugees = new List<IssueFurtherReading>
            {
                new IssueFurtherReading
                {
                    LinkName = "Should asylum seekers have unrestricted rights to work in the UK?",
                    LinkUrl = "http://researchbriefings.parliament.uk/ResearchBriefing/Summary/SN01908",
                    Description = "House of Commons Briefings",
                    DisplayExternalIcon = false
                },
                new IssueFurtherReading
                {
                    LinkName = "Syrian refugees and the UK",
                    LinkUrl = "http://researchbriefings.parliament.uk/ResearchBriefing/Summary/SN06805",
                    Description = "House of Commons Briefings",
                    DisplayExternalIcon = false
                },
                new IssueFurtherReading
                {
                    LinkName = "Asylum Statistics",
                    LinkUrl = "http://researchbriefings.parliament.uk/ResearchBriefing/Summary/SN01403",
                    Description = "House of Commons Briefings",
                    DisplayExternalIcon = false
                },
                new IssueFurtherReading
                {
                    LinkName = "Statistics on Migrants and Benefits",
                    LinkUrl = "http://researchbriefings.parliament.uk/ResearchBriefing/Summary/CBP-7445",
                    Description = "House of Commons Briefings",
                    DisplayExternalIcon = false
                },
                new IssueFurtherReading
                {
                    LinkName = "The EU's response to the migration crisis: recent developments",
                    LinkUrl = "http://researchbriefings.parliament.uk/ResearchBriefing/Summary/CBP-7430",
                    Description = "House of Commons Briefings",
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
                    Title = "Refugees and Asylum",
                    LogicalOrder = 4,
                    Content = issueContentForRefugees.ToString(),
                    TimeLines = timelinesForRefugees,
                    FurtherReadings = furtherReadingsForRefugees,
                    Image = dbImage,
                    ImageType = dbImageType
                }
            };

            var issueActions = new List<IssueAction>
            {
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[2],
                    IsPrimary = true,
                    LogicalOrder = 1,
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content = "<p>Sign a petition about refugees or asylum policy schools. The Government must respond to petitions that get 10,000 signatures. A petition that receives 100,000 signatures may be debated in Parliament.</p>"
                        },
                        new IssueActionContent
                        {
                            Key = "Keywords",
                            Content = "Refugees"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[0],
                    IsPrimary = false,
                    LogicalOrder = 2
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
                            Content = "Write to a Peer in the House of Lords"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content = "http://www.parliament.uk/mps-lords-and-offices/lords/"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Write to a Peer"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "Approx 30mins"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content = "<p>Members of the Lords do not represent geographic areas (constituencies), you can search members by area of policy interest using the search options menu in the Members of the House of Lords section.</p>"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[0],
                    ActionItem = actionItems[3],
                    IsPrimary = true,
                    LogicalOrder = 4
                },
            };

            context.Issues.AddOrUpdate(issues.ToArray());
            context.ActionItems.AddOrUpdate(actionItems.ToArray());
            context.IssueActions.AddOrUpdate(issueActions.ToArray());
        }
    }
}