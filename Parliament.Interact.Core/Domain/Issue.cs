using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parliament.Interact.Core.Domain
{
    public class Issue
    {
        [Key]
        public int Id { get;set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        public string Title { get; set; }
        public int LogicalOrder { get; set; }
        public List<ActionItem> ActionItems { get; set; } 

        public List<IssueTimeLine> TimeLines { get; set; } 
        public List<IssueFurtherReading> FurtherReadings { get; set; }
    }
}