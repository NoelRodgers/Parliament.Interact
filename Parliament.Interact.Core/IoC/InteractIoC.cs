using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parliament.Interact.Core.ActionsViewFactory;
using Parliament.Interact.Core.ActionsViewFactory.Items;
using StructureMap.Configuration.DSL;

namespace Parliament.Interact.Core.IoC
{
    public class InteractIoC : Registry
    {
        public InteractIoC()
        {
           // For<IActionsViewModelFactoryItem>().Add<ContactYourMPViewModelBuilder>();
        }
    }
}
