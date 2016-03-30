using Parliament.Common.ContentReader;
using Parliament.Common.Interfaces;
using Parliament.MPContact.Settings;
using Parliament.Common.Extensions;
using Parliament.Common.Serialization;

namespace Parliament.MPContact.Services
{
    public class MemberContactService : IMemberContactService
    {

        private const string _urlFormat = "{0}/fymp={1}";
        private readonly IUriContentReaderService _contentReaderService;
        private readonly MemberSettings _settings;

        public MemberContactService(IConfigurationBuilder configurationBuilder, IUriContentReaderService contentReaderService)
        {
            _contentReaderService = contentReaderService;
            _settings = configurationBuilder.GetConfiguration<MemberSettings>("Members");
        }

        public IMember GetMember(string postcode)
        {
            var url = _urlFormat.FormatString(_settings.BaseUrl, postcode);

            var xmlResult = _contentReaderService.Read(url);

            var data = XmlUtility.DeserializeXml<Member>(xmlResult);

            return data;

        }
    }
}
