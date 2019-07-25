using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AntiDepressantWebApplication.Models
{
    public class AddExerciseViewModel
    {
        [Required]
        [DisplayName("Location")]
        public string Location { get; set; }
    }
}