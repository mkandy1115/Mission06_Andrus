using System.ComponentModel.DataAnnotations;

namespace Mission06_Andrus.Models
{
    public class AddMovie
    {   
        // Primary Key
        [Key]
        public int MovieId { get; set; }

        // Required fields
        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        // Optional 
        public bool? Edited { get; set; }

        // Optional
        public string? LentTo { get; set; }

        // Optional + max 25 characters
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}