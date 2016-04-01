namespace Parliament.Interact.Web.Models
{
    public class ActionItemViewModel
    { 
        public string Title { get; set; }
        public string Eta { get; set; }
        public string BasicContent { get; set; }

        public string ActionView { get; set; }
        public object ActionModel { get; set; }

        public bool IsPrimary { get; set; }
    }
}