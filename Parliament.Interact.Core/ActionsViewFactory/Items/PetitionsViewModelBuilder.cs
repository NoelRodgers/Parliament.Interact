using System.Diagnostics.CodeAnalysis;
using Parliament.Common.Extensions;
using Parliament.Common.Interfaces;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;
using Parliament.Interact.Core.Petitions;
using Parliament.Interact.Core.Petitions.Settings;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.ActionsViewFactory.Items
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class PetitionsViewModelBuilder : IActionsViewModelFactoryItem
    {
        private readonly IPetitionsService _service;
        private PetitionsSettings _settings;

        public PetitionsViewModelBuilder(IPetitionsService service, IConfigurationBuilder configurationBuilder)
        {
            _service = service;
            _settings = configurationBuilder.GetConfiguration<PetitionsSettings>("Petitions");
        }

        public ActionViewName ActionName { get { return ActionViewName.Petitions; } }

        public string Title { get { return "Sign a Petition"; } }

        public string ActionView { get { return "_Petitions"; } }

        public object BuildViewModel(Issue issue)
        {
            var petitions = _service.GetTopPetitionsForPhrase("Academy Schools");
            return new PetitionsModel
            {
                Petitions = petitions.SelectToListIndex(BuildPetitionViewModel),
                MaxCount = _settings.MaxCount,
                CreateUrl = _settings.BaseUrl + _settings.CreateUrlPart,
                ViewAllUrl = _service.GetViewAllSearchLink("Academy Schools")
            };
        }

        private PetitionItemModel BuildPetitionViewModel(IPetition petition, int index)
        {
            return new PetitionItemModel
            {
                Link = petition.Link,
                LinkName = petition.ProposedAction,
                SignatureCount = petition.SignatureCount,
                LogicalOrder = index + 1
            };
        }
    }
}