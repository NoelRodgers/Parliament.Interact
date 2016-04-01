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

        public List<ActionItemViewModel> Build(Issue issue, params ActionViewName[] actionNames)
        {
            var actions = _actionsModelFactory.GetActionsByName<IActionsViewModelFactoryItem>(actionNames);
            return actions.SelectToList(x => BuildActionItemViewModel(x, issue));
        }

        public ActionItemViewModel BuildActionItemViewModel(IActionsViewModelFactoryItem item, Issue issue)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            // Suppressed as Title is sometimes built from BuildViewModel
            var primaryIssueAction = issue.IssueActions.Single(x => x.IsPrimary);
            var actionsBasePath = "Actions/{0}";

            if (primaryIssueAction == null)
            {
                actionsBasePath = "Actions/Small/{0}";
            }

            var model = new ActionItemViewModel
            {
                ActionView = actionsBasePath.FormatString(item.ActionView),
                ActionModel = item.BuildViewModel(issue)
            };

            model.Title = item.Title;
            model.Eta = item.Eta;
            model.BasicContent = item.BasicContent;

            return model;
        }
    }
}