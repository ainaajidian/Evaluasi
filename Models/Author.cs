using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Evaluasi.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string MainCategory { get; set; }

        public ICollection<Course> Course { get; set; }
    }
}
