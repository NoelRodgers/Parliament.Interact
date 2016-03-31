using System.Collections.Generic;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Web.Models
{
    public class IssueViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }
        public int LogicalOrderId { get; set; }
        public string BackgroundColorClass { get; set; }
        public byte[] DbImageBase64 { get; set; }
        public string ImageType { get; set; }
        public bool HasImage { get; set; }
        public List<FurtherReadingViewModel> FurtherReadings { get; set; }        
        public List<ActionItemViewModel> ActionsItems { get; set; }
        public List<TimeLineViewModel> TimeLines { get; set; } 
    }
}