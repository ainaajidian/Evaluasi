using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluasi.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        public int AuthorID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }

        public Author Author { get; set; }
    }
}
