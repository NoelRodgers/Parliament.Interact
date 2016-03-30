using System;
using System.Diagnostics.CodeAnalysis;
using Parliament.Common.Interfaces;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;
using Parliament.MPContact;
using Parliament.MPContact.Settings;

namespace Parliament.Interact.Core.ActionsViewFactory.Items
{
    [SuppressMessage("ReSharper", "ConvertPropertyToExpressionBody")] //Supressed as if we let Resharper do that it will break if we try to build on msbuild with our .NET Version!
    public class ContactYourMPViewModelBuilder : IActionsViewModelFactoryItem
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
        public object BuildViewModel()
        {
            var memberData = _service.GetMember("RG45AF"); //hard-coded for now to check
            return new ContactYourMPModel
            {
                Link = _service.BuildLink(memberData)
            };
        }
    }
}