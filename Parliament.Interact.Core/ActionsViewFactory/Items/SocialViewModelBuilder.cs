using System.Diagnostics.CodeAnalysis;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items.Base;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.ActionsViewFactory.Items
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class SocialViewModelBuilder : ActionsItemViewModelBuilderBase, IActionsViewModelFactoryItem
    {
        public override ActionViewName ActionName { get { return ActionViewName.Social; } }

        public string ActionView { get { return "_Social"; } }

        public object BuildViewModel(Issue issue)
        {
            Build(issue);
            return null;
        }

    }
}