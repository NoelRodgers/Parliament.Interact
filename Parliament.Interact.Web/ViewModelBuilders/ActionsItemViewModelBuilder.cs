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
            var model = new ActionItemViewModel
            {
                ActionView = "Actions/{0}".FormatString(item.ActionView),
                ActionModel = item.BuildViewModel(issue)
            };

            model.Title = item.Title;
            model.Eta = item.Eta;
            model.BasicContent = item.BasicContent;

            return model;
        }
    }
}