﻿using System.Collections.Generic;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Web.Models
{
    public class IssueViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }
        public IList<IssueTimeLine> TimeLines { get; set; } 
    }
}