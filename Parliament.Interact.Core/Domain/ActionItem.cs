﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Parliament.Interact.Core.ActionsViewFactory.Enum;

namespace Parliament.Interact.Core.Domain
{
    public class ActionItem
    {
        [Key]
        public int Id { get; set; }

        public ActionViewName ViewName { get; set; }

        public List<Issue> Issues { get; set; }
    }
}