using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AntiDepressantWebApplication.Models
{
    public class AddDiaryEntryViewModel
    {
        [Required]
        [StringLength(5000)]
        [DisplayName("New Entry")]
        public string Text { get; set; }
    }
}