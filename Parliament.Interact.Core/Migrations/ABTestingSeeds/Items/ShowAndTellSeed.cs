using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.Domain.Context;

namespace Parliament.Interact.Core.Migrations.ABTestingSeeds
{
    //This is the base seed
    public class ShowAndTellSeed : IABTestingItem
    {
        public string ConfigurationName
        {
            get { return "ShowAndTell"; }
        }

        public void Seed(InteractDbContext context)
        {
            #region Content

            var issueContentForRefugees = new StringBuilder();
            issueContentForRefugees.Append("<p>As the Government administers and develops the process for handling refugees in the UK, Members of the House of Commons and Peers in the House of Lords work to look at how well existing process are working and what the impact of proposed changes will be.</p>");
            issueContentForRefugees.Append("<p>The United Nations High Commission for Refugees (UNHCR) warned in 2015 that the world is in the midst of a forced migration crisis. It see the Syrian conflict as the biggest cause. Huge numbers of people are dying trying to cross the Mediterranean to Southern Europe from Libya. European Countries are struggling to deal with the numbers reaching their boarders, and securing agreement within the EU on a coordinated response is proving difficult.</p>");
            issueContentForRefugees.Append("<p>The total number of people applying for asylum in EU counties increased from a monthly average of 22, 000 in 2010 to 110, 000 in 2015. Asylum applications in EU countries reached their highest level in October 2015 at 172, 000, falling to 109, 000 in December 2015. The number of asylum applications to the UK peaked in 2002 at 84, 132.After that the number fell sharply to reach a twenty year low point of 17, 916 in 2010, before rising slowly to reach 32, 414 in 2015.</p>");
            issueContentForRefugees.Append("<p>The Government is planning to resettle up to 20,000 Syrian refugees in the UK by the end of this Parliament in 2020.</p>");

            var issueContentAcademySchools = new StringBuilder();
            issueContentAcademySchools.Append(
                "<p>The Government announced in March 2016 that every primary and secondary state school become an academy. (George Osborne, <a href='http://www.publications.parliament.uk/pa/cm201516/cmhansrd/cm160316/debtext/160316-0001.htm#16031632000621'>Budget Statement, 16 March 2016 <i class='fa fa-external'></i></a>)</p>");
            issueContentAcademySchools.Append(
                "<p>Academies are state schools, independent of local authority control. They are funded directly by central government rather than by local authorities. By 2015 almost 60% of state-funded secondary schools were academies, up from 6% at the start of 2010.</p>");
            issueContentAcademySchools.Append(
                "<h5>Should state schools become independent of local authority control?</h5>");
            issueContentAcademySchools.Append(
                "<p>Government argues that freedom from local authority control brings opportunities for innovation, better leadership and higher attainment and that academies have had a positive impact on other schools in their local area.</p>");
            issueContentAcademySchools.Append(
                "<p>Others say that the freedoms afforded to academies, and their rapid expansion, have the potential to result in financial problems and lapses in standards. (House of Commons Library, <a href='http://www.parliament.uk/business/publications/research/key-issues-parliament-2015/education/academies-and-free-schools/'>Key Issues for the 2015 Parliament</a>)</p>");

            var issueContentEUReferendum = new StringBuilder();
            issueContentEUReferendum.Append(
                "<p>On 23 June 2016, the United Kingdom will be voting in a referendum asking “Should the United Kingdom remain a member of the European Union or leave the European Union?”</p>");
            issueContentEUReferendum.Append(
                "<p>The European Union (EU) is an economic and political partnership involving 28 countries. The last referendum was in 1975 when the UK voted to stay in but over the last 40 years there have been calls from both the public and politicians for another vote. Arguments for leaving and staying in the EU are currently being put forward by different groups and individuals.</p>");
            issueContentEUReferendum.Append("<h5>Arguments for and against the EU Referendum</h5>");
            issueContentEUReferendum.Append(
                "<p>You can read relevant reports, evidence and information on the impact of leaving or staying in the EU on the Commons and Lords Library’s summary page: <a href='http://www.parliament.uk/business/publications/research/eu-referendum'>The UK’s EU referendum 2016 explained.</a></p>");
            issueContentEUReferendum.Append("<h5>How can I register to vote?</h5>");
            issueContentEUReferendum.Append(
                "<p>The Electoral Commission, an independent body, coordinates voter registration, referendums and elections. To vote in the EU Referendum you must register by the 7 June. Registration is quick and simple and can be completed by citizens of England, Scotland or Wales through <a href='http://www.electoralcommission.org.uk/i-am-a/voter'>online voter registration.</a></p>");
            issueContentEUReferendum.Append(
                "<p>If you are based in Northern Ireland you can download a <a href='http://www.aboutmyvote.co.uk/register-to-vote/register-to-vote-in-northern-ireland'>voter registration form.</a></p>");

            var issueContentForInvestigatoryPowers = new StringBuilder();
            issueContentForInvestigatoryPowers.Append("<p>The Home Office introduced the Investigatory Powers Bill on 1 March 2016. The Bill covers changes to the operation and regulation of the investigatory powers used by the police and the intelligence and security agencies.</p>");
            issueContentForInvestigatoryPowers.Append("<p>The Bill’s aims include bringing together current legislation on the interception, retention and use of communications data and create a single body for overseeing warrants to investigatory services led by an Investigatory Powers Commissioner.</p>");
            issueContentForInvestigatoryPowers.Append("<p>One potential change in the Bill would affect what communications data Police or other agencies could access. Currently Police or other agencies can access communications data such as historic phone bills; the proposed new legislation could allow them to ask firms to hold and share with them more information, such as which online services have been used by an individual.</p>");
            issueContentForInvestigatoryPowers.Append("<p>There are currently debates and discussions taking place in and outside of Parliament about the arguments for and against the proposed changes in the Bill. </p>");
            #endregion Content

            #region Actions
            var actionItems = new List<ActionItem>
            {
                new ActionItem
                {
                    ViewName = ActionViewName.ContactYourMP,
                    ActionContents = new List<ActionContent>()
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
                            Content =
                                "<p>Write to your MP about academy schools. Your MP represents you. They can raise your concerns in Parliament and question Government.</p>"
                        }
                    }
                },
                new ActionItem
                {
                    ViewName = ActionViewName.Links,
                    ActionContents = new List<ActionContent>
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
                    }
                },
                new ActionItem
                {
                    ViewName = ActionViewName.Petitions,
                    ActionContents = new List<ActionContent>
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
                            Content =
                                "<p>Sign or Start a petition about academy schools. The Government must respond to petitions that get 10,000 signatures. A petition that receives 100,000 signatures may be debated in Parliament.</p>"
                        }
                    }
                },
                new ActionItem
                {
                    ViewName = ActionViewName.Social,
                    ActionContents = new List<ActionContent>
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
                            Content =
                                "<p>Share this page about Academy Schools with your social network, friends, family and colleagues to get more people involved in this issue.</p>",
                        },
                    }
                }
            };
            #endregion Actions

            #region Timelines
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


            var timeLinesAcademySchools = new List<IssueTimeLine>
            {
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Past,
                    HTMLContent =
                        "<p>On 16 March the Chancellor, George Osborne, presented his Budget to Parliament and announced that by the end of 2020, every school in England should be an academy or free school – or be in the process of becoming one.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Present,
                    HTMLContent =
                        "<p>The House of Commons Education Committee is running an inquiry into the performance, accountability & governance of Multi-Academy Trusts. <a href='http://www.parliament.uk/business/committees/committees-a-z/commons-select/education-committee/inquiries/parliament-2015/multi-academy-trusts-15-16/'>Inquiry: Multi - Academy Trusts</a> <i class='fa fa-external'></i></p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Future,
                    HTMLContent =
                        "<p>On 27 April, the Education Select Committee is due to question Nicky Morgan, Secretary of State for Education, on the Government's policy 'Educational Excellence Everywhere' which includes the proposal for every school to become a free school or academy.</p>"
                }
            };

            var timeLinesEuReferendum = new List<IssueTimeLine>()
            {
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Past,
                    HTMLContent =
                        "<p>The Prime Minister announced a Referendum will be held on the 23 June 2016 so that members of the public can vote on whether the UK should stay in or leave the EU.</p><p>In February 2016 the Prime Minister agreed a range of changes to the UK's membership of the EU after talks with other Member States' leaders in Brussels. The agreement, would take effect immediately if the UK votes to remain in the EU.</ p >"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Present,
                    HTMLContent =
                        "<p>Currently a House of Commons Select Committee is investigating the implications for UK businesses should the UK leave the EU, they are accepting evidence from the public until the 15 April 2016.</p>"
                },
                new IssueTimeLine
                {
                    TimelineType = TimeLineType.Future,
                    HTMLContent =
                        "<p>The EU Referendum vote will be held on the 23 June 2016. You must be registered to vote by 7 June 2016 to take part.</p>"
                },

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

            #endregion TimeLine

            #region Further Reading
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


            var furtherReadingsAcademySchools = new List<IssueFurtherReading>
            {
                new IssueFurtherReading
                {
                    LinkName = "Read a report by the Education Commitee",
                    LinkUrl =
                        "http://www.parliament.uk/business/committees/committees-a-z/commons-select/education-committee/news/academies-and-free-schools-government-response-to-be-published/",
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
                    LinkUrl =
                        "https://www.gov.uk/government/news/nicky-morgan-unveils-new-vision-for-the-education-system",
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

            #endregion Further Readings

            var academySchoolsImage = GetImage("school.jpg");
            var euReferendumImage = GetImage("eu-referendum.jpg");
            var investigatoryPowersImage = GetImage("investigatory-powers.jpg");
            var refugeesImage = GetImage("refugees.jpg");

            #region Issues

            var issues = new List<Issue>
            {
                new Issue
                {
                    Title = "Academy Schools",
                    LogicalOrder = 1,
                    Content = issueContentAcademySchools.ToString(),
                    TimeLines = timeLinesAcademySchools,
                    FurtherReadings = furtherReadingsAcademySchools,
                    Image = academySchoolsImage.Image,
                    ImageType = academySchoolsImage.ImageType
                },
                new Issue
                {
                    Title = "EU Referendum",
                    LogicalOrder = 2,
                    Content = issueContentEUReferendum.ToString(),
                    TimeLines = timeLinesEuReferendum,
                    FurtherReadings = furtherReadingsEuRreferendum,
                    Image = euReferendumImage.Image,
                    ImageType = euReferendumImage.ImageType
                },
                new Issue
                {
                    Title = "Investigatory Powers",
                    LogicalOrder = 4,
                    Content = issueContentForInvestigatoryPowers.ToString(),
                    TimeLines = timelinesForInvestigatoryPowers,
                    FurtherReadings = furtherReadingsForInvestigatoryPowers,
                    Image = investigatoryPowersImage.Image,
                    ImageType = investigatoryPowersImage.ImageType
                },
                new Issue
                {
                    Title = "Refugees and Asylum",
                    LogicalOrder = 3,
                    Content = issueContentForRefugees.ToString(),
                    TimeLines = timelinesForRefugees,
                    FurtherReadings = furtherReadingsForRefugees,
                    Image = refugeesImage.Image,
                    ImageType = refugeesImage.ImageType
                }
            };

            #endregion Issues

            #region IssueActions
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
                            Content =
                                "http://www.parliament.uk/business/committees/committees-a-z/commons-select/education-committee/inquiries/parliament-2015/multi-academy-trusts-15-16/"
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
                            Content =
                                "<p>Send your views on groups of academy schools (Multiple-Academy Trusts) to the House of Commons Education Committee. The Committee can use information you provide to help it question Ministers or make recommendations to Government.</p>"
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
                            Content =
                                "<p>Sign or start a petition about this issue. The Government must respond to petitions that get 10,000 signatures. A petition that receives 100,000 signatures may be debated in Parliament.</p>"
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
                            Content =
                                "<p>Could you help set a school's direction and ensure that its budget is properly managed?</p><p><a href=\"https://www.gov.uk/government/get-involved/take-part/volunteer-as-a-school-governor\">Read more on GOV.UK</a></p>"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[1],
                    ActionItem = actionItems[1],
                    IsPrimary = true,
                    LogicalOrder = 1,
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "Title",
                            Content = "Register to Vote by 7 June 2016"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content = "https://www.gov.uk/register-to-vote"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Register to Vote"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "Approx 20mins"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content =
                                "<p>Make sure you are registered to vote by 7 June 2016 to take part. Proxy and postal vote options are available if you are not able to attend a polling station on the day.</p>"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[1],
                    ActionItem = actionItems[1],
                    IsPrimary = false,
                    LogicalOrder = 2,
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
                            Content =
                                "http://www.parliament.uk/business/committees/committees-a-z/commons-select/business-innovation-and-skills/inquiries/parliament-2015/inquiry/"
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
                            Content =
                                "<p>The House of Commons Business, Innovations and Skills Committee is running an inquiry to test business reasons cited by businesses on both sides of the EU referendum debate. They are looking for evidence and views from businesses, unions, consumer bodies and the wider public. Submissions can be made online.</p>"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[1],
                    ActionItem = actionItems[1],
                    IsPrimary = false,
                    LogicalOrder = 3,
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "Title",
                            Content = "Join an EU campaign group"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content = "http://www.electoralcommission.org.uk/"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Join a group"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "Approx 30mins"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content =
                                "<p>The Electoral Commission will list registered campaigners for and against leaving the EU in mid April. You will be able to find out the registered EU campaign groups on the website</p>"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[1],
                    ActionItem = actionItems[0],
                    IsPrimary = false,
                    LogicalOrder = 4
                },
                new IssueAction
                {
                    Issue = issues[1],
                    ActionItem = actionItems[1],
                    IsPrimary = false,
                    LogicalOrder = 5,
                    IssueActionContents = new List<IssueActionContent>
                    {
                        new IssueActionContent
                        {
                            Key = "Title",
                            Content = "Explore the Treasury Committee's EU inquiry evidence"
                        },
                        new IssueActionContent
                        {
                            Key = "Link",
                            Content =
                                "http://www.parliament.uk/business/committees/committees-a-z/commons-select/treasury-committee/inquiries1/parliament-2015/eu-membership-15-16/"
                        },
                        new IssueActionContent
                        {
                            Key = "LinkName",
                            Content = "Explore evidence"
                        },
                        new IssueActionContent
                        {
                            Key = "Eta",
                            Content = "Approx up to 1hr"
                        },
                        new IssueActionContent
                        {
                            Key = "BasicContent",
                            Content =
                                "<p>Explore the evidence submitted to the Treasury Committee EU inquiry into the potential economic and financial implications of leaving the EU.</p>"
                        }
                    }
                },
                new IssueAction
                {
                    Issue = issues[1],
                    ActionItem = actionItems[3],
                    IsPrimary = true,
                    LogicalOrder = 6
                },
                                new IssueAction
                {
                    Issue = issues[2],
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
                    Issue = issues[2],
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
                    Issue = issues[2],
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
                    Issue = issues[2],
                    ActionItem = actionItems[0],
                    IsPrimary = false,
                    LogicalOrder = 3
                },
                new IssueAction
                {
                    Issue = issues[2],
                    ActionItem = actionItems[3],
                    IsPrimary = true,
                    LogicalOrder = 5
                },
                new IssueAction
                {
                    Issue = issues[2],
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
                },new IssueAction
                {
                    Issue = issues[3],
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
                    Issue = issues[3],
                    ActionItem = actionItems[0],
                    IsPrimary = false,
                    LogicalOrder = 2
                },
                new IssueAction
                {
                    Issue = issues[3],
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
                    Issue = issues[3],
                    ActionItem = actionItems[3],
                    IsPrimary = true,
                    LogicalOrder = 4
                }
            };
            #endregion IssueActions

            context.Issues.AddOrUpdate(issues.ToArray());
            context.ActionItems.AddOrUpdate(actionItems.ToArray());
            context.IssueActions.AddOrUpdate(issueActions.ToArray());
        }

        private ImageContext GetImage(string fileName)
        {
            var filename = new UriBuilder(Assembly.GetExecutingAssembly().CodeBase);
            var path = Uri.UnescapeDataString(filename.Path);
            var directory = Path.GetDirectoryName(path) + "\\Migrations\\{0}".FormatString(fileName);
            var originalImage = System.Drawing.Image.FromFile(directory);
            var dbImageType = MimeMapping.GetMimeMapping(directory);
            byte[] dbImage;

                using (var ms = new MemoryStream())
                {
                    originalImage.Save(ms, originalImage.RawFormat);
                    dbImage = ms.ToArray();
                }
            return new ImageContext {ImageType = dbImageType, Image = dbImage};
        }


        internal sealed class ImageContext
        {
            public string ImageType { get; set; }
            public byte[] Image { get; set; }
        }
    }


}