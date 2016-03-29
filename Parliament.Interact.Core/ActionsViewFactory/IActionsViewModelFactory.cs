using System.Collections.Generic;
using Parliament.Interact.Core.ActionsViewFactory.Enum;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    public interface IActionsViewModelFactory
    {
        List<IActionsViewModelFactoryItem> GetActionsByName(List<ActionViewName> actionNames);
    }
}