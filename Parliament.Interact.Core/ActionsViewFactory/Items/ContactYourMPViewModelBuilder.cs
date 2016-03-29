using System.Diagnostics.CodeAnalysis;
using Parliament.Common.Interfaces;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;

namespace Parliament.Interact.Core.ActionsViewFactory.Items
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class ContactYourMPViewModelBuilder : IActionsViewModelFactoryItem
    {
        public ActionViewName ActionName { get { return ActionViewName.ContactYourMP; } }
        public string Title { get { return "Contact your MP"; } }
        public string ActionView { get { return "_ContactYourMP"; } }
        public object BuildViewModel()
        {
            return new ContactYourMPModel();
        }
    }
}