using System.Collections.Generic;

namespace Parliament.Interact.Web.Models
{
    public class IssueViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }
        public int LogicalOrderId { get; set; }
        public string BackgroundColorClass { get; set; }

        public List<FurtherReadingViewModel> FurtherReadings { get; set; }
        
        public List<TimeLineViewModel> TimeLines { get; set; } 
    }
}