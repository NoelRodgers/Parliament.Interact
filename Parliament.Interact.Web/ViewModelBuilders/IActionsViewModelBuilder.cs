using System.Collections.Generic;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Web.Models;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Web.ViewModelBuilders
{
    public interface IActionsItemViewModelBuilder
    {
        List<ActionItemViewModel> Build(Issue issue, params ActionViewName[] actionNames);
    }
}