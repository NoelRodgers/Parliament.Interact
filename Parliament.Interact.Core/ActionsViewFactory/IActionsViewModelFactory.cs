using System.Collections.Generic;
using Parliament.Interact.Core.ActionsViewFactory.Enum;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    public interface IActionsViewModelFactory
    {
        List<T> GetActionsByName<T>(params ActionViewName[] actionNames)
              where T : IActionsViewModelFactoryItem;
    }
}