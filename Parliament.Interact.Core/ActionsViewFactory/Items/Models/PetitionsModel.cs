using System.Collections.Generic;

namespace Parliament.Interact.Core.ActionsViewFactory.Items.Models
{
    public class PetitionsModel
    {
        public int PetitionMaxCount { get; set; }
        public List<PetitionItemModel> Petitions { get; set; }
    }
}