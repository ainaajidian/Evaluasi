
using System.ComponentModel.DataAnnotations;

namespace Evaluasi.Dtos
{
    public class CourseForCreateDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Maks. 100 Karakter")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500, ErrorMessage = "Maks. 1500 Karakter")]
        public string Description { get; set; }
    }
}
