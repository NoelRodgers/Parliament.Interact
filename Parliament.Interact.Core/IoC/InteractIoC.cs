using Parliament.Interact.Core.ActionsViewFactory;
using Parliament.Interact.Core.ActionsViewFactory.Items;
using Parliament.Interact.Core.Migrations.ABTestingSeeds;
using Parliament.Interact.Core.Migrations.ABTestingSeeds.Items;
using StructureMap.Configuration.DSL;

namespace Parliament.Interact.Core.IoC
{
    public class InteractIoC : Registry
    {
        public InteractIoC()
        {
            For<IActionsViewModelFactoryItem>().Add<ContactYourMPViewModelBuilder>();
            For<IActionsViewModelFactoryItem>().Add<PetitionsViewModelBuilder>();
            For<IActionsViewModelFactoryItem>().Add<LinkViewModelBuilder>();

            For<IABTestingItem>().Add<ABTestingSeedA>();
            For<IABTestingItem>().Add<ABTestingSeedB>();
            For<IABTestingItem>().Add<ABTestingSeedC>();
        }
    }
}
