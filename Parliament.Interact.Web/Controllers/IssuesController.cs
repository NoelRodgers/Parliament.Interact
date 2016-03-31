using System;
using System.Drawing;
using System.IO;
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

        public ActionResult GetImageFile(int issueId)
        {
            var model = _issueViewModelBuilder.Build(issueId);
            return File(model.DbImageBase64, model.ImageType);
        }

        [HttpPost]
        public ActionResult GetMPLink(ContactYourMPModel model)
        {
            var action = _actionsModelFactory.GetActionsByName<IActionsViewModelFactoryItemWithInputModel>(ActionViewName.ContactYourMP);
            if (string.IsNullOrEmpty(model.Postcode))
            {
                ModelState.Clear();
                model.ErrorMessage = "Please enter a valid postcode.";
                return PartialView("~/Views/Issues/Actions/_ContactYourMP.cshtml", model);
            }
            var result = (ContactYourMPResultModel)action.First().BuildViewModel(model.Postcode);
            if (string.IsNullOrEmpty(result.RedirectLink))
            {
                model.Postcode = "";
                model.ErrorMessage = "Please enter a valid postcode.";
                ModelState.Clear();
                return PartialView("~/Views/Issues/Actions/_ContactYourMP.cshtml", model);
            }

            return JavaScript("window.location = '" + result.RedirectLink + "'");
        }
    }
}