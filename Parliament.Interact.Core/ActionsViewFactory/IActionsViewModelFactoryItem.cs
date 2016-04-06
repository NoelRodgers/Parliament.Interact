using Parliament.Common.Interfaces;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    public interface IActionsViewModelFactoryItem : IPluggable
    {
        ActionViewName ActionName { get; }
        string Title { get; }
        string Eta { get; }
        string BasicContent { get; }
        string ActionView { get; }
        bool DistributeOverTwoColumns { get; }
        object BuildViewModel(Issue issue, IssueAction issueAction);
    }

    public interface IActionsViewModelFactoryItemWithInputModel : IActionsViewModelFactoryItem
    {
        object BuildViewModel<T>(T inputModel);
    }
}