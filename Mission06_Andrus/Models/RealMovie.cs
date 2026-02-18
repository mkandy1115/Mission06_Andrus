using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Andrus.Models
{
    public class RealMovie
    {
        // Primary Key
        [Key]
        public int MovieId { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 3000, ErrorMessage = "Year must be 1888 or later.")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please select if the movie was edited.")]
        public int? Edited { get; set; }

        [Required(ErrorMessage = "Please select if the movie was copied to Plex.")]
        public int? CopiedToPlex { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
        public string? Notes { get; set; }
    }
}
