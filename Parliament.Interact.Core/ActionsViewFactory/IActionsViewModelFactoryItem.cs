using Parliament.Common.Interfaces;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    public interface IActionsViewModelFactoryItem : IPluggable
    {
        ActionViewName ActionName { get; }
        string Title { get; }
        string ActionView { get; }
        object BuildViewModel(Issue issue);
    }

    public interface IActionsViewModelFactoryItemWithInputModel : IActionsViewModelFactoryItem
    {
        object BuildViewModel<T>(T inputModel);
    }
}