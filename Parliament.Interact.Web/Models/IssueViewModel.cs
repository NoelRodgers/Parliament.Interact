using System.Collections.Generic;

namespace Parliament.Interact.Web.Models
{
    public class IssueViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }

        public List<FurtherReadingViewModel> FurtherReadings { get; set; }

    }
}