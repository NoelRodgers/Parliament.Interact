using System.Web.Mvc;
using Parliament.Interact.Core.Services;

namespace Parliament.Interact.Web.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService _issueService;

        public IssuesController(IIssueService issueService)
        {
            _issueService = issueService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}