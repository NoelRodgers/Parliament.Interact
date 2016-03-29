using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parliament.Interact.Core.Domain
{
    public class IssueTimeLine
    {
        [Key]
        public int Id { get; set; }

        public TimeLine Timeline { get; set; }

        [Column(TypeName = "ntext")]
        public string HTMLContent { get; set; }

    }
}