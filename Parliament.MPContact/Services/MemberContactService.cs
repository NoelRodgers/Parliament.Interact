using Parliament.Common.ContentReader;
using Parliament.Common.Interfaces;
using Parliament.MPContact.Settings;
using Parliament.Common.Extensions;
using Parliament.Common.Serialization;
using Parliament.MPContact.Contracts;
using System.Linq;

namespace Parliament.MPContact.Services
{
    public class MemberContactService : IMemberContactService
    {

        private const string _urlMNISFormat = "{0}services/mnis/members/query/fymp={1}";
        private const string _urlParliamentFormat = "{0}/biographies/commons/{1}/{2}";
        private readonly IUriContentReaderService _contentReaderService;
        private readonly MemberSettings _settings;

        public MemberContactService(IConfigurationBuilder configurationBuilder, IUriContentReaderService contentReaderService)
        {
            _contentReaderService = contentReaderService;
            _settings = configurationBuilder.GetConfiguration<MemberSettings>("Members");
        }

        public MemberContract GetMember(string postcode)
        {
            var url = _urlMNISFormat.FormatString(_settings.BaseUrl, postcode);

            var xmlResult = _contentReaderService.Read(url);

            var data = XmlUtility.DeserializeXml<MemberContract>(xmlResult);

            return data;

        }

        public string BuildLink(MemberContract data)
        {
            var firstMember = data.Members.FirstOrDefault();
            if (firstMember == null) return null;

            var id = firstMember.Id;
            var name = firstMember.DisplayName;
            var formattedName = name.ToLower().Replace(" ", "-");

            var link = _urlParliamentFormat.FormatString(_settings.BiographyBaseUrl, formattedName, id);

            return link;
        }
    }
}
