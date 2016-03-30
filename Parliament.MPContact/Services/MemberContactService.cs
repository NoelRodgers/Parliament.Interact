using Parliament.Common.ContentReader;
using Parliament.Common.Interfaces;
using Parliament.MPContact.Settings;
using Parliament.Common.Extensions;
using Parliament.Common.Serialization;
using Parliament.MPContact.Contracts;

namespace Parliament.MPContact.Services
{
    public class MemberContactService : IMemberContactService
    {

        private const string _urlFormat = "http://data.parliament.uk/membersdataplatform/services/mnis/members/query/fymp={0}"; // change to use base url from settings
        private readonly IUriContentReaderService _contentReaderService;
        private readonly MemberSettings _settings;

        public MemberContactService(IConfigurationBuilder configurationBuilder, IUriContentReaderService contentReaderService)
        {
            _contentReaderService = contentReaderService;
            _settings = configurationBuilder.GetConfiguration<MemberSettings>("Members");
        }

        public MemberContract GetMember(string postcode)
        {
            var url = _urlFormat.FormatString(postcode); // change to pass _settings.baseurl

            var xmlResult = _contentReaderService.Read(url);

            var data = XmlUtility.DeserializeXml<MemberContract>(xmlResult);

            return data;

        }

        public string BuildLink(MemberContract data)
        {
            var id = data.Member.Id;
            var name = data.Member.DisplayName;
            var formattedName = name.ToLower().Replace(" ", "-");

            return "http://www.parliament.uk/biographies/commons/" + formattedName + "/" + id;
        }
    }
}
