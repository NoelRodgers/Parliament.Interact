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

        public List<T> GetActionsByName<T>(params ActionViewName[] actionNames)
            where T : IActionsViewModelFactoryItem
        {
            return _actions.WhereToList(x => actionNames.ToList().Contains(x.ActionName)).SelectToList(x => (T)x);
        }
    }
}