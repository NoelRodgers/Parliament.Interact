using System.Collections.Generic;
using Newtonsoft.Json;
using Parliament.Common.ContentReader;
using Parliament.Common.Extensions;
using Parliament.Common.Interfaces;
using Parliament.Interact.Core.Petitions.Contract;
using Parliament.Interact.Core.Petitions.Settings;

namespace Parliament.Interact.Core.Petitions
{
    public class PetitionsService : IPetitionsService
    {
        private const string _urlFormat = "{0}/petitions.json?q={1}&state=open";
        private readonly IUriContentReaderService _contentReaderService;
        private readonly PetitionsSettings _settings;

        public PetitionsService(IConfigurationBuilder configurationBuilder, IUriContentReaderService contentReaderService)
        {
            _contentReaderService = contentReaderService;
            _settings = configurationBuilder.GetConfiguration<PetitionsSettings>("Petitions");
        }

        public List<IPetition> GetTopPetitionsForPhrase(string petitionsSearchPhrase, int maxPetitions = 3)
        {
            var url = _urlFormat.FormatString(_settings.BaseUrl.Trim('/'), petitionsSearchPhrase);

            var jsonResult = _contentReaderService.Read(url);

            var petitionsContract = JsonConvert.DeserializeObject<PetitionContract>(jsonResult);

            return petitionsContract.Petitions.SelectToList(BuildPetitions);
        }

        private IPetition BuildPetitions(PetitionDataItem dataItem)
        {
            return new Petititon
            {
                Background = dataItem.Attributes.Background,
                Link = dataItem.Links.Self,
                ProposedAction = dataItem.Attributes.Action,
                SignatureCount = dataItem.Attributes.SignatureCount
            };
        }
    }
}