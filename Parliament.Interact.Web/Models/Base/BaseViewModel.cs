using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parliament.Interact.Web.Models.Base
{
    public abstract class BaseViewModel
    {
        public string GoogleAnalyticsCode { get; set; }
        public string TagManager { get; set; }
    }
}