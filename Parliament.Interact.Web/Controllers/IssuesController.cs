using System.Web.Mvc;
using Parliament.Interact.Web.Models;
using Parliament.Interact.Web.ViewModelBuilders;

namespace Parliament.Interact.Web.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueViewModelBuilder _issueViewModelBuilder;

        public IssuesController(IIssueViewModelBuilder issueViewModelBuilder)
        {
            _issueViewModelBuilder = issueViewModelBuilder;
        }

        public ActionResult Index()
        {
            var model = _issueViewModelBuilder.Build();

            return View(model);
        }

        [HttpPost]
        public ActionResult GetMPLink(string value)
        {
            var postcode = value;
            return RedirectToAction("Index");
        }
    }
}