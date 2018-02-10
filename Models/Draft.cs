using System;
using System.ComponentModel.DataAnnotations;

namespace owdrafter.Models
{
    public class Draft
    {
        [Key]
        public int DraftId { get; set; }
        public DateTime DraftDate { get; set; }
        [Required(ErrorMessage = "At least one user left.")]
        public User FirstUser { get; set; }
        [Required(ErrorMessage = "At least one user left.")]
        public User SecondUser { get; set; }
    }
}