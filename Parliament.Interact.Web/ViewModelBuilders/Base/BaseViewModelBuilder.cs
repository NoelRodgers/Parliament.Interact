using Parliament.Common.Interfaces;
using Parliament.Interact.Web.Models.Base;

namespace Parliament.Interact.Web.ViewModelBuilders.Base
{
    public class BaseViewModelBuilder : IBaseViewModelBuilder
    {
        private readonly BaseViewModelSettings _settings;

        public BaseViewModelBuilder(IConfigurationBuilder configurationBuilder)
        {
            _settings = configurationBuilder.GetConfiguration<BaseViewModelSettings>();
        }

        public T Build<T>() where T : BaseViewModel, new()
        {
            var model = new T
            {
                GoogleAnalyticsCode = _settings.GoogleAnalyticsCode,
                TagManager = _settings.TagManager,
                DisplayGoogleExperiments = _settings.DisplayGoogleExperiments
            };

            return model;
        }
    }
}