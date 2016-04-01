using System.Collections.Generic;
using Parliament.Interact.Core.ActionsViewFactory.Enum;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    public interface IActionsViewModelFactory
    {
        T GetActionsByName<T>(ActionViewName actionViewName)
              where T : IActionsViewModelFactoryItem;
    }
}