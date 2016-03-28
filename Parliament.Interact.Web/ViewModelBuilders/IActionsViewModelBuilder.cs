using System.Collections.Generic;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Web.Models;

namespace Parliament.Interact.Web.ViewModelBuilders
{
    public interface IActionsItemViewModelBuilder
    {
        List<ActionItemViewModel> Build(params ActionViewName[] actionNames);
    }
}