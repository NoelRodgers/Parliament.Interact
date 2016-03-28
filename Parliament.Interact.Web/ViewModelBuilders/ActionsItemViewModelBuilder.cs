using System.Collections.Generic;
using System.Linq;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.ActionsViewFactory;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Web.Models;

namespace Parliament.Interact.Web.ViewModelBuilders
{
    public class ActionsItemViewModelBuilder : IActionsItemViewModelBuilder
    {
        private readonly IActionsViewModelFactory _actionsModelFactory;

        public ActionsItemViewModelBuilder(IActionsViewModelFactory actionsModelFactory)
        {
            _actionsModelFactory = actionsModelFactory;
        }

        public List<ActionItemViewModel> Build(params ActionViewName[] actionNames)
        {
            var actions = _actionsModelFactory.GetActionsByName(actionNames.ToList());
            return actions.SelectToList(BuildActionItemViewModel);
        }

        public ActionItemViewModel BuildActionItemViewModel(IActionsViewModelFactoryItem item)
        {
            return new ActionItemViewModel
            {
                Title = item.Title,
                ActionView = item.ActionView,
                ActionModel = item.BuildViewModel()
            };
        }
    }
}