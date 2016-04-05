using Parliament.Interact.Web.Models.Base;

namespace Parliament.Interact.Web.ViewModelBuilders.Base
{
    public interface IBaseViewModelBuilder
    {
        T Build<T>() where T : BaseViewModel, new();
    }
}