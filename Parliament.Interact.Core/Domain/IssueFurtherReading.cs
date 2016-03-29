using System.ComponentModel.DataAnnotations;

namespace Parliament.Interact.Core.Domain
{
    public class IssueFurtherReading
    {
        [Key]
        public int Id { get; set; }

        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public bool DisplayExternalIcon { get; set; }
    }
}
