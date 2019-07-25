using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AntiDepressantWebApplication.Models
{
    public class DiaryEntry
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        [Required]
        [StringLength(5000)]
        [AllowHtml]
        public string Text { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}