using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parliament.Interact.Core.Domain
{
    public class IssueAction
    {
        [Key]
        public int Id { get; set; }
 
        public Issue Issue { get; set; }

        public ActionItem ActionItem { get; set; }

        public List<IssueActionContent> IssueActionContents { get; set; }
        public bool IsPrimary { get; set; }
        public int LogicalOrder { get; set; }
    }
}