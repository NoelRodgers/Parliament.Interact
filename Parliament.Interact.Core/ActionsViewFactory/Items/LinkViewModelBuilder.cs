﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items.Base;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;

namespace Parliament.Interact.Core.ActionsViewFactory
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class LinkViewModelBuilder : ActionsItemViewModelBuilderBase, IActionsViewModelFactoryItem
    {
        public override ActionViewName ActionName
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

        public bool DistributeOverTwoColumns { get { return true; } }

        public object BuildViewModel(Issue issue, IssueAction issueAction)
        {
            Build(issueAction);
            var linkContent = GetActionContent(issueAction, "Link").Content;
            var linkNameContent = GetActionContent(issueAction, "LinkName").Content;
            return new LinkModel
            {
                Link = linkContent,
                LinkName = linkNameContent
            };
        }
    }
}
