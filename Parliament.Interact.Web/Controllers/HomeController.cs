using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parliament.Common.Interfaces;
using Parliament.Common.IoC;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.ActionsViewFactory.Items;
using Parliament.Interact.Web.ViewModelBuilders;

namespace Parliament.Interact.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActionsItemViewModelBuilder _viewModelBuilder;
        public HomeController(IActionsItemViewModelBuilder viewModelBuilder)
        {
            _viewModelBuilder = viewModelBuilder;
        }

        public ActionResult Index()
        {
            Bootstrapper.Build();
            var model = _viewModelBuilder.Build(ActionViewName.ContactYourMP);
            return View(model.First().ActionView, model.First().ActionModel);
        }
    }
}