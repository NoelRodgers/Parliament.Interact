using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parliament.Interact.Core.Domain
{
    public class IssueActionContent : IActionContent
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public string Key { get; set; }
    }
}