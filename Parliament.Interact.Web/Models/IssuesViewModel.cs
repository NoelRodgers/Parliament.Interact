using System.Collections.Generic;
using Parliament.Interact.Web.Models.Base;

namespace Parliament.Interact.Web.Models
{
    public class IssuesViewModel : BaseViewModel
    {
        public List<IssueViewModel> Issues { get; set; }
    }
}