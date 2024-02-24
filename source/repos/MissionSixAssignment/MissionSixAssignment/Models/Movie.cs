using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MissionSixAssignment.Models;

namespace MissionSixAssignment.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required]

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Title { get; set; }
        
        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "The year must be greater than or equal to 1888.")]
        public int? Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }

        [Required]
        public bool? Edited { get; set; }= false;
        public string? LentTo { get; set; }
        public bool? CopiedToPlex { get; set; }

        public string? Notes { get; set; }
   


    }


}
