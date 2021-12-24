using Evaluasi.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Evaluasi.Dtos
{
    public class AuthorForCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maks. 50 Karakter")]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maks. 50 Karakter")]
        public string MainCategory { get; set; }
    }
}
