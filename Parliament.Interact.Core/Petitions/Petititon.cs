namespace Parliament.Interact.Core.Petitions
{
    public class Petititon : IPetition
    {
        public string Link { get; set; }
        public string ProposedAction { get; set; }
        public string Background { get; set; }
        public int SignatureCount { get; set; }
    }
}