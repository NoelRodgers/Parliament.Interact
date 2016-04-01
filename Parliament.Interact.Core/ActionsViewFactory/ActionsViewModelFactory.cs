using System.Collections.Generic;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using System.Linq;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    public class ActionsViewModelFactory : IActionsViewModelFactory
    {
        private readonly IList<IActionsViewModelFactoryItem> _actions;

        public ActionsViewModelFactory(IList<IActionsViewModelFactoryItem> actions)
        {
            _actions = actions;
        }

        public T GetActionsByName<T>(ActionViewName actionViewName)
            where T : IActionsViewModelFactoryItem
        {
            return (T)_actions.SingleOrDefault(x => x.ActionName == actionViewName);
        }
    }
}