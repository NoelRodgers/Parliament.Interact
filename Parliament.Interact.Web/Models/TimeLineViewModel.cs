using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Web.Models
{
    public class TimeLineViewModel
    {
        public TimeLineType TimelineType { get; set; }

        public string HTMLContent { get; set; }
        public string Title { get; set; }
    }
}