using System.Collections.Generic;

namespace Parliament.Interact.Core.Petitions
{
    public interface IPetitionsService
    {
        List<IPetition> GetTopPetitionsForPhrase(string petitionsSearchPhrase, int maxPetitions = 3);
        string GetViewAllSearchLink(string petitionsSearchPhrase);
    }
}