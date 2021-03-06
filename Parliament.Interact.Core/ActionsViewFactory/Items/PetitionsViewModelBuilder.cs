﻿using System.Diagnostics.CodeAnalysis;
using Parliament.Common.Extensions;
using Parliament.Common.Interfaces;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items.Base;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;
using Parliament.Interact.Core.Petitions;
using Parliament.Interact.Core.Petitions.Settings;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.ActionsViewFactory.Items
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class PetitionsViewModelBuilder : ActionsItemViewModelBuilderBase, IActionsViewModelFactoryItem
    {
        private readonly IPetitionsService _service;
        private PetitionsSettings _settings;

        public PetitionsViewModelBuilder(IPetitionsService service, IConfigurationBuilder configurationBuilder)
        {
            _service = service;
            _settings = configurationBuilder.GetConfiguration<PetitionsSettings>("Petitions");
        }

        public override ActionViewName ActionName { get { return ActionViewName.Petitions; } }

        public string ActionView { get { return "_Petitions"; } }

        public bool DistributeOverTwoColumns { get { return false; } }

        public object BuildViewModel(Issue issue, IssueAction issueAction)
        {
            Build(issueAction);
            var keywords = GetActionContent(issueAction, "Keywords").Content;
            var petitions = _service.GetTopPetitionsForPhrase(keywords);
            return new PetitionsModel
            {
                Petitions = petitions.SelectToListIndex(BuildPetitionViewModel),
                MaxCount = _settings.MaxCount,
                CreateUrl = _settings.BaseUrl + _settings.CreateUrlPart,
                ViewAllUrl = _service.GetViewAllSearchLink(keywords)
            };
        }

        private PetitionItemModel BuildPetitionViewModel(IPetition petition, int index)
        {
            return new PetitionItemModel
            {
                Link = petition.Link.Replace(".json", string.Empty),
                LinkName = petition.ProposedAction,
                SignatureCount = petition.SignatureCount,
                LogicalOrder = index + 1
            };
        }
    }
}