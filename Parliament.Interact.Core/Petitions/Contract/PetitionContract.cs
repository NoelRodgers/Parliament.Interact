using System.Collections.Generic;
using Newtonsoft.Json;

namespace Parliament.Interact.Core.Petitions.Contract
{
    public class PetitionContract
    {
         [JsonProperty("data")]
         public List<PetitionDataItem> Petitions { get; set; }
    }

    public class PetitionDataItem
    {
        [JsonProperty("links")]
        public PetitionsLinkItem Links { get; set; }

        [JsonProperty("attributes")]
        public PetitionsAttributesItem Attributes { get; set; }
    }

    public class PetitionsLinkItem
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public class PetitionsAttributesItem
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("signature_count")]
        public int SignatureCount { get; set; }

        [JsonProperty("additional_details")]
        public string AdditionalDetails { get; set; }
    }


}