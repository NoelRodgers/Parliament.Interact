using System.Collections.Generic;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.ActionsViewFactory.Enum;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    public class ActionsViewModelFactory : IActionsViewModelFactory
    {
        private readonly IList<IActionsViewModelFactoryItem> _actions;

        public ActionsViewModelFactory(IList<IActionsViewModelFactoryItem> actions)
        {
            _actions = actions;
        }

        public List<IActionsViewModelFactoryItem> GetActionsByName(List<ActionViewName> actionNames)
        {
            return _actions.WhereToList(x => actionNames.Contains(x.ActionName));
        }
    }
}