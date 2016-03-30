using System.Web.Mvc;
using Parliament.Interact.Web.Models;
using Parliament.Interact.Web.ViewModelBuilders;
using Parliament.Interact.Core.ActionsViewFactory;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using System.Linq;
using Parliament.Interact.Core.ActionsViewFactory.Items.Models;

namespace Parliament.Interact.Web.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueViewModelBuilder _issueViewModelBuilder;
        private readonly IActionsViewModelFactory _actionsModelFactory;

        public IssuesController(IIssueViewModelBuilder issueViewModelBuilder, IActionsViewModelFactory actionsModelFactory)
        {
            _issueViewModelBuilder = issueViewModelBuilder;
            _actionsModelFactory = actionsModelFactory;
        }

        public ActionResult Index()
        {
            var model = _issueViewModelBuilder.Build();

            return View(model);
        }

        [HttpPost]
        public ActionResult GetMPLink(ContactYourMPModel model)
        {
            if(string.IsNullOrEmpty(model.Postcode))
            {
                return Redirect("Index");
            }
            var action = _actionsModelFactory.GetActionsByName<IActionsViewModelFactoryItemWithInputModel>(ActionViewName.ContactYourMP);
            var result = (ContactYourMPResultModel)action.First().BuildViewModel(model.Postcode);
            if (string.IsNullOrEmpty(result.RedirectLink))
            {
                return Redirect("Index");
            }

            return new RedirectResult(result.RedirectLink, true);
        }
    }
}