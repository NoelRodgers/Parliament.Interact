﻿using System;
using System.Diagnostics.CodeAnalysis;
using Parliament.Common.Interfaces;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;
using Parliament.MPContact;
using Parliament.MPContact.Settings;
using Parliament.Common.Extensions;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.ActionsViewFactory.Items
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class ContactYourMPViewModelBuilder : IActionsViewModelFactoryItemWithInputModel
    {
        private readonly IMemberContactService _service;
        private MemberSettings _settings;

        public ContactYourMPViewModelBuilder(IMemberContactService service, IConfigurationBuilder configurationBuilder)
        {
            _service = service;
            _settings = configurationBuilder.GetConfiguration<MemberSettings>("Members");
        }

        public ActionViewName ActionName { get { return ActionViewName.ContactYourMP; } }
        public string Title { get { return "Contact your MP"; } }
        public string ActionView { get { return "_ContactYourMP"; } }
        public object BuildViewModel(Issue issue)
        {
            return new ContactYourMPModel();
        }

        public object BuildViewModel<T>(T inputModel)
        {
            if (typeof(T) != typeof(string)) throw new InvalidOperationException("The model {0} is not supported for this operation".FormatString(typeof(T).AssemblyQualifiedName));
            var postcode = inputModel.ToString();

            var memberData = _service.GetMember(postcode);

            return new ContactYourMPResultModel
            {
                RedirectLink = _service.BuildLink(memberData)
            };
        }
    }
}