using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.Services;
using Parliament.Interact.Web.Models;

namespace Parliament.Interact.Web.ViewModelBuilders
{
    public class IssueViewModelBuilder : IIssueViewModelBuilder
    {
        private readonly IIssueService _issueService;
        private readonly IActionsItemViewModelBuilder _actionsViewModelBuilder;

        public IssueViewModelBuilder(IIssueService issueService, IActionsItemViewModelBuilder actionsViewModelBuilder)
        {
            _issueService = issueService;
            _actionsViewModelBuilder = actionsViewModelBuilder;
        }

        public IList<IssueViewModel> Build()
        {
            var issues = _issueService.GetTopFiveIssues();
            return issues.SelectToList(BuildIssueViewModel);
        }

        public IssueViewModel Build(int id)
        {
            var issue = _issueService.GetIssueById(id);
            return BuildIssueViewModel(issue);
        }

        private FurtherReadingViewModel BuildFurtherReadingViewModel(IssueFurtherReading reading)
        {
            return new FurtherReadingViewModel
            {
                    LinkName = reading.LinkName,
                    LinkUrl = reading.LinkUrl,
                    DisplayExternalIcon = reading.DisplayExternalIcon
            };
        }

        private TimeLineViewModel BuildTimeLineViewModel(IssueTimeLine timeline)
        {
            var model = new TimeLineViewModel
            {
                TimelineType = timeline.TimelineType,
                HTMLContent = timeline.HTMLContent,
            };

            var title = "";
            if (model.TimelineType == TimeLineType.Past)
            {
                title = "What's happened";
            }
            if (model.TimelineType == TimeLineType.Present)
            {
                title = "What's happening";
            }
            if (model.TimelineType == TimeLineType.Future)
            {
                title = "What's happening next";
            }

            model.Title = title;

            return model;
        }

        private string AssignBackGroundColorClass(int logicalOrderId)
        {
            if (logicalOrderId % 3 == 0)
            {
                return "orangeHeaderBackground";
            }

            if (logicalOrderId % 3 == 1)
            {
                return "blueHeaderBackground";
            }

            if (logicalOrderId % 3 == 2)
            {
                return "purpleHeaderBackground";
            }
            else
            {
                return "";
            }
        }

        private IssueViewModel BuildIssueViewModel(Issue issue)
        {
            var type = "";
            if (issue.ImageType == ImageTypeEnumerable.Jpeg)
            {
                type = "jpg";
            }
            if (issue.ImageType == ImageTypeEnumerable.Svg)
            {
                type = "svg";
            }
            if (issue.ImageType == ImageTypeEnumerable.Png)
            {
                type = "png";
            }
            if (issue.ImageType == ImageTypeEnumerable.Gif)
            {
                type = "gif";
            }
            return new IssueViewModel
            {
                Content = issue.Content,
                Id = issue.Id,
                Title = issue.Title,
                LogicalOrderId = issue.LogicalOrder,
                BackgroundColorClass = AssignBackGroundColorClass(issue.LogicalOrder),
                FurtherReadings = issue.FurtherReadings.SelectToList(BuildFurtherReadingViewModel),
                TimeLines = issue.TimeLines.SelectToList(BuildTimeLineViewModel),
                ActionsItems = _actionsViewModelBuilder.Build(issue.IssueActions.SelectToList(x => x.ActionItem.ViewName).ToArray()),
                DbImageBase64 = issue.Image,
                ImageType = type,
                HasImage = issue.Image != null
            };
        }
    }
}