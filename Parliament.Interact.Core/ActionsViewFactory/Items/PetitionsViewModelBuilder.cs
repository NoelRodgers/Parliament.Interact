using System.Diagnostics.CodeAnalysis;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;
using Parliament.Interact.Core.Petitions;

namespace Parliament.Interact.Core.ActionsViewFactory.Items
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class PetitionsViewModelBuilder : IActionsViewModelFactoryItem
    {
        private readonly IPetitionsService _service;

        public PetitionsViewModelBuilder(IPetitionsService service)
        {
            _service = service;
        }

        public ActionViewName ActionName { get { return ActionViewName.Petitions; } }

        public string Title { get { return "Sign a Petition"; } }

        public string ActionView { get { return "_Petitions"; } }

        public object BuildViewModel()
        {
            var petitions = _service.GetTopPetitionsForPhrase("Academy Schools");
            return new PetitionsModel
            {
                Petitions = petitions.SelectToListIndex(BuildPetitionViewModel)
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