namespace Parliament.Interact.Core.Petitions
{
    public interface IPetition
    {
        string Link { get; set; }
        string ProposedAction { get; set; }
        string Background { get; set; }
        int SignatureCount { get; set; }
    }
}