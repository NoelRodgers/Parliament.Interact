﻿using System;
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
    //This is the seed for listing only one action
    public class ABTestingSeedC : IABTestingItem
    {
        public string ConfigurationName { get { return "C"; } }
        public void Seed(InteractDbContext context)
        {
            var issueContent = new StringBuilder();
            issueContent.Append("<p>The Government announced in March 2016 that every primary and secondary state school become an academy. (George Osborne, <a href='http://www.publications.parliament.uk/pa/cm201516/cmhansrd/cm160316/debtext/160316-0001.htm#16031632000621'>Budget Statement, 16 March 2016 <i class='fa fa-external'></i></a>)</p>");
            issueContent.Append("<p>Academies are state schools, independent of local authority control. They are funded directly by central government rather than by local authorities. By 2015 almost 60% of state-funded secondary schools were academies, up from 6% at the start of 2010.</p>");
            issueContent.Append("<h5>Should state schools become independent of local authority control?</h5>");
            issueContent.Append("<p>Government argues that freedom from local authority control brings opportunities for innovation, better leadership and higher attainment and that academies have had a positive impact on other schools in their local area.</p>");
            issueContent.Append("<p>Others say that the freedoms afforded to academies, and their rapid expansion, have the potential to result in financial problems and lapses in standards. (House of Commons Library, <a href='http://www.parliament.uk/business/publications/research/key-issues-parliament-2015/education/academies-and-free-schools/'>Key Issues for the 2015 Parliament <i class='fa fa-external'></i></a>)</p>");
            var actionItems = new List<ActionItem>
            {
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
                }}
            };

            var timelines = new List<IssueTimeLine>
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

            var furtherReadings = new List<IssueFurtherReading>
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
                    ActionItem = actionItems[0],
                    IsPrimary = true,
                    LogicalOrder = 1
                }
            };

            context.Issues.AddOrUpdate(issues.ToArray());
            context.ActionItems.AddOrUpdate(actionItems.ToArray());
            context.IssueActions.AddOrUpdate(issueActions.ToArray());
        }
    }
}
