using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.Domain.Context;

namespace Parliament.Interact.Core.Migrations.ABTestingSeeds
{
    //This is the base seed
    public class EUReferendumSeeds : IABTestingItem
    {
        public string ConfigurationName { get { return "EUReferendum"; } }
        public void Seed(InteractDbContext context)
        {
            var issueContentAcademySchools = new StringBuilder();
            issueContentAcademySchools.Append("<p>The Government announced in March 2016 that every primary and secondary state school become an academy. (George Osborne, <a href='http://www.publications.parliament.uk/pa/cm201516/cmhansrd/cm160316/debtext/160316-0001.htm#16031632000621'>Budget Statement, 16 March 2016 <i class='fa fa-external'></i></a>)</p>");
            issueContentAcademySchools.Append("<p>Academies are state schools, independent of local authority control. They are funded directly by central government rather than by local authorities. By 2015 almost 60% of state-funded secondary schools were academies, up from 6% at the start of 2010.</p>");
            issueContentAcademySchools.Append("<h5>Should state schools become independent of local authority control?</h5>");
            issueContentAcademySchools.Append("<p>Government argues that freedom from local authority control brings opportunities for innovation, better leadership and higher attainment and that academies have had a positive impact on other schools in their local area.</p>");
            issueContentAcademySchools.Append("<p>Others say that the freedoms afforded to academies, and their rapid expansion, have the potential to result in financial problems and lapses in standards. (House of Commons Library, <a href='http://www.parliament.uk/business/publications/research/key-issues-parliament-2015/education/academies-and-free-schools/'>Key Issues for the 2015 Parliament</a>)</p>");

            var issueContentEUReferendum = new StringBuilder();
            issueContentEUReferendum.Append("<p>On 23 June 2016, the United Kingdom will be voting in a referendum asking “Should the United Kingdom remain a member of the European Union or leave the European Union?”</p>");
            issueContentEUReferendum.Append("<p>The European Union (EU) is an economic and political partnership involving 28 countries. The last referendum was in 1975 when the UK voted to stay in but over the last 40 years there have been calls from both the public and politicians for another vote. Arguments for leaving and staying in the EU are currently being put forward by different groups and individuals.</p>");
            issueContentEUReferendum.Append("<h5>Arguments for and against the EU Referendum</h5>");
            issueContentEUReferendum.Append("<p>You can read relevant reports, evidence and information on the impact of leaving or staying in the EU on the Commons and Lords Library’s summary page: <a href='http://www.parliament.uk/business/publications/research/eu-referendum'>The UK’s EU referendum 2016 explained.</a></p>");
            issueContentEUReferendum.Append("<h5>How can I register to vote?</h5>");
            issueContentEUReferendum.Append("<p>The Electoral Commission, an independent body, coordinates voter registration, referendums and elections. To vote in the EU Referendum you must register by the 7 June. Registration is quick and simple and can be completed by citizens of England, Scotland or Wales through <a href='http://www.electoralcommission.org.uk/i-am-a/voter'>online voter registration.</a></p>");
            issueContentEUReferendum.Append("<p>If you are based in Northern Ireland you can download a <a href='http://www.aboutmyvote.co.uk/register-to-vote/register-to-vote-in-northern-ireland'>voter registration form.</a></p>");

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

            var timeLinesAcademySchools = new List<IssueTimeLine>
            {
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Past,
                    HTMLContent = "<p>On 16 March the Chancellor, George Osborne, presented his Budget to Parliament and announced that by the end of 2020, every school in England should be an academy or free school – or be in the process of becoming one.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Present,
                    HTMLContent = "<p>The House of Commons Education Committee is running an inquiry into the performance, accountability & governance of Multi-Academy Trusts. <a href='http://www.parliament.uk/business/committees/committees-a-z/commons-select/education-committee/inquiries/parliament-2015/multi-academy-trusts-15-16/'>Inquiry: Multi - Academy Trusts</a> <i class='fa fa-external'></i></p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Future,
                    HTMLContent = "<p>On 27 April, the Education Select Committee is due to question Nicky Morgan, Secretary of State for Education, on the Government's policy 'Educational Excellence Everywhere' which includes the proposal for every school to become a free school or academy.</p>"
                }
            };

            var timeLinesEuReferendum = new List<IssueTimeLine>()
            {
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Past,
                    HTMLContent = "<p>The Prime Minister announced a Referendum will be held on the 23 June 2016 so that members of the public can vote on whether the UK should stay in or leave the EU.</p><p>In February 2016 the Prime Minister agreed a range of changes to the UK's membership of the EU after talks with other Member States' leaders in Brussels. The agreement, would take effect immediately if the UK votes to remain in the EU.</ p >"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Present,
                    HTMLContent = "<p>Currently a House of Commons Select Committee is investigating the implications for UK businesses should the UK leave the EU, they are accepting evidence from the public until the 15 April 2016.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Future,
                    HTMLContent = "<p>The EU Referendum vote will be held on the 23 June 2016. You must be registered to vote by 7 June 2016 to take part.</p>"
                },

            };

            var furtherReadingsAcademySchools = new List<IssueFurtherReading>
            {
                new IssueFurtherReading
                {
                    LinkName = "Read a report by the Education Commitee",
                    LinkUrl = "http://www.parliament.uk/business/committees/committees-a-z/commons-select/education-committee/news/academies-and-free-schools-government-response-to-be-published/",
                    Description = "about Academies and Free Schools (January 2015)",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "BBC News article",
                    LinkUrl = "http://www.bbc.co.uk/news/education-13274090",
                    Description = "What does it mean to be an Academy School? (BBC News, March 2016)",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "Nicky Morgan’s Press release",
                    LinkUrl = "https://www.gov.uk/government/news/nicky-morgan-unveils-new-vision-for-the-education-system",
                    Description = "Nicky Morgan unveils new vision for the education system (GOV.UK, March 2016)",
                    DisplayExternalIcon = true
                }
            };

            var furtherReadingsEuRreferendum = new List<IssueFurtherReading>
            {
                new IssueFurtherReading
                {
                    LinkName = "The UK’s EU referendum 2016 explained",
                    LinkUrl =
                        "http://www.parliament.uk/eu-referendum",
                    Description = "Parliament information on the EU referendum",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "News updates on EU activity in Parliament",
                    LinkUrl =
                        "http://www.parliament.uk/business/news/european-union/",
                    Description = "Parliament updates",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "Inquiries and reports from the EU Lords Committee",
                    LinkUrl =
                        "http://www.parliament.uk/business/committees/committees-a-z/lords-select/eu-select-committee-/news-parliament-2015/eu-visions-report-published/",
                    Description = "House of Lords EU Committee",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "Electoral Commission website",
                    LinkUrl =
                        "http://www.electoralcommission.org.uk/",
                    Description = "Who can vote and the referendum process",
                    DisplayExternalIcon = true
                },
                new IssueFurtherReading
                {
                    LinkName = "The UK's EU vote: All you need to know",
                    LinkUrl = "http://www.bbc.co.uk/news/politics/eu_referendum",
                    Description = "BBC on EU referendum",
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
                    Title = "Academy Schools",
                    LogicalOrder = 1,
                    Content = issueContentAcademySchools.ToString(),
                    TimeLines = timeLinesAcademySchools,
                    FurtherReadings = furtherReadingsAcademySchools,
                    Image = dbImage,
                    ImageType = dbImageType
                },
                new Issue
                {
                    Title = "EU Referendum",
                    LogicalOrder = 2,
                    Content = issueContentEUReferendum.ToString(),
                    TimeLines = timeLinesEuReferendum,
                    FurtherReadings = furtherReadingsEuRreferendum,
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
                            Content = "http://www.parliament.uk/business/committees/committees-a-z/commons-select/education-committee/inquiries/parliament-2015/multi-academy-trusts-15-16/"
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
                            Content = "<p>Send your views on groups of academy schools (Multiple-Academy Trusts) to the House of Commons Education Committee. The Committee can use information you provide to help it question Ministers or make recommendations to Government.</p>"
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
                            Content = "Academy Schools"
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
                            Content = "Volunteer as a school governor"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content = "https://www.gov.uk/become-school-college-governor"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Apply Online"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "Over 1hr"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content = "<p>Could you help set a school's direction and ensure that its budget is properly managed?</p><p><a href=\"https://www.gov.uk/government/get-involved/take-part/volunteer-as-a-school-governor\">Read more on GOV.UK</a></p>"
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
