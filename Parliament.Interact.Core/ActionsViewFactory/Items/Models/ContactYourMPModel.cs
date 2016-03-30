using System.ComponentModel.DataAnnotations;

namespace Parliament.Interact.Core.ActionsViewFactory.Items.Models
{
    public class ContactYourMPModel
    {
        [Required(ErrorMessage = "Please enter a postcode")]
        public string Postcode { get; set; }

        public string ErrorMessage { get; set; }
    }
}