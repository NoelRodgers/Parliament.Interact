using System.Collections.Generic;

namespace Parliament.Interact.Core.ActionsViewFactory.Items.Models
{
    public class PetitionsModel
    {
        public int MaxCount { get; set; }
        public List<PetitionItemModel> Petitions { get; set; }
        public string CreateUrl { get; set; }
        public object ViewAllUrl { get; set; }
    }
}