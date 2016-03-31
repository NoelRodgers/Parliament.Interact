using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parliament.Interact.Core.Domain
{
    public class ActionContent
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public string Key { get; set; }
    }
}