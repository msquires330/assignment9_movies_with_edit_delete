using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace assignment3_msquires.Models
{
    public class NewMovieResponse
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Category is Required")]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Category { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
       
        [Required(ErrorMessage = "Year is Required")]
        [StringLength(4)]
        public string Year { get; set; }

        [Required(ErrorMessage = "Director is Required")]
        public string Director { get; set; }
        
        [Required(ErrorMessage = "Rating is Required")]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? Rating { get; set; }
        public string Edited { get; set; }
        public string Lent { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
