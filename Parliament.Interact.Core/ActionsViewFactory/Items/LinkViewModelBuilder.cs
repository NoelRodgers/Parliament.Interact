using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class LinkViewModelBuilder : IActionsViewModelFactoryItem
    {
        public ActionViewName ActionName
        {
            get
            {
                return ActionViewName.Links;
            }
        }

        public string ActionView
        {
            get
            {
                return "_Links";
            }
        }

        public string Title
        {
            get; private set;
        }

        public object BuildViewModel(Issue issue)
        {
            var issueAction = issue.IssueActions.Single(x => x.ActionItem.ViewName == ActionName);
            var linkContent = issueAction.IssueActionContents.Single(x => x.Key == "Link");
            var linkNameContent = issueAction.IssueActionContents.Single(x => x.Key == "LinkName");
            Title = issueAction.IssueActionContents.Single(x => x.Key == "Title").Content;
            return new LinkModel
            {
                Link = linkContent.Content,
                LinkName = linkNameContent.Content
            };
        }
    }
}
