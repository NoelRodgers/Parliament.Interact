using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parliament.Interact.Core.Domain
{
    public class Issue
    {
        [Key]
        public int Id { get;set; }

        public string Description { get; set; }
        public string Title { get; set; }
        public int LogicalOrder { get; set; }

        public List<ActionItem> ActionItems { get; set; }
        public List<IssueFurtherReading> FurtherReadings { get; set; }
    }
}