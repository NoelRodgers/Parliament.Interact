using Parliament.Common.Interfaces;
using Parliament.Interact.Core.ActionsViewFactory.Enum;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    public interface IActionsViewModelFactoryItem : IPluggable
    {
        ActionViewName ActionName { get; }
        string Title { get; }
        string ActionView { get; }
        object BuildViewModel();
    }

    public interface IActionsViewModelFactoryItemWithInputModel : IActionsViewModelFactoryItem
    {
        object BuildViewModel<T>(T inputModel);
    }
}