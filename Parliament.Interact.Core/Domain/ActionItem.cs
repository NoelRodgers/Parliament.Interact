using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parliament.Interact.Core.Domain
{
    public class ActionItem
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Issue> Issues { get; set; }
    }
}