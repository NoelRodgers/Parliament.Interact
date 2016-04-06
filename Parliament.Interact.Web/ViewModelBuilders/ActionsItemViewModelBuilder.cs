using System.Collections.Generic;
using System.Linq;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.ActionsViewFactory;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Web.Models;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Web.ViewModelBuilders
{
    public class ActionsItemViewModelBuilder : IActionsItemViewModelBuilder
    {
        private readonly IActionsViewModelFactory _actionsModelFactory;

        public ActionsItemViewModelBuilder(IActionsViewModelFactory actionsModelFactory)
        {
            _actionsModelFactory = actionsModelFactory;
        }

        public List<ActionItemViewModel> Build(Issue issue)
        {
            var orderedActions =
                issue.IssueActions.OrderBy(x => x.LogicalOrder)
                    .SelectToList(x => new { ViewModelBuilder =_actionsModelFactory.GetActionsByName<IActionsViewModelFactoryItem>(x.ActionItem.ViewName), IssueAction = x });

            return orderedActions.SelectToList(x => BuildActionItemViewModel(x.ViewModelBuilder, x.IssueAction, issue));
        }

        public ActionItemViewModel BuildActionItemViewModel(IActionsViewModelFactoryItem item, IssueAction issueAction, Issue issue)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            // Suppressed as Title is sometimes built from BuildViewModel

            var actionsBasePath = issueAction.IsPrimary ? "Actions/{0}" : "Actions/Small/{0}";

            var model = new ActionItemViewModel
            {
                ActionView = actionsBasePath.FormatString(item.ActionView),
                ActionModel = item.BuildViewModel(issue, issueAction)
            };

            model.Title = item.Title;
            model.Eta = item.Eta;
            model.BasicContent = item.BasicContent;
            model.IsPrimary = issueAction.IsPrimary;
            model.DistributeOverTwoColumns = issueAction.IsPrimary && item.DistributeOverTwoColumns;

            return model;
        }
    }
}