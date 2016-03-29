using System.Collections.Generic;
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

        private TimeLineViewModel BuildTimeLineViewModel(IssueTimeLine timeline)
        {
            return new TimeLineViewModel
            {
                TimelineType = timeline.TimelineType,
                HTMLContent = timeline.HTMLContent
            };
        }
        private IssueViewModel BuildIssueViewModel(Issue issue)
        {
            return new IssueViewModel
            {
                Content = issue.Content,
                Id = issue.Id,
                Title = issue.Title,
                TimeLines = issue.TimeLines.SelectToList(BuildTimeLineViewModel),
                ActionsItems = _actionsViewModelBuilder.Build(issue.IssueActions.SelectToList(x => x.ActionItem.ViewName).ToArray())
            };
        }
    }
}