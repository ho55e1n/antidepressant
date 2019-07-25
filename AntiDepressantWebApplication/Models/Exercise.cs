using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntiDepressantWebApplication.Models
{
    public class Exercise
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}