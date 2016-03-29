﻿using System.Collections.Generic;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.Services;
using Parliament.Interact.Web.Models;

namespace Parliament.Interact.Web.ViewModelBuilders
{
    public class IssueViewModelBuilder : IIssueViewModelBuilder
    {
        private readonly IIssueService _issueService;

        public IssueViewModelBuilder(IIssueService issueService)
        {
            _issueService = issueService;
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
        private IssueViewModel BuildIssueViewModel(Issue issue)
        {
            return new IssueViewModel
            {
                Content = issue.Content,
                Id = issue.Id,
                Title = issue.Title,
                TimeLines = issue.TimeLines.SelectToList(BuildTimeLineViewModel)
            };
        }
    }
}