using Evaluasi.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Evaluasi.ValidationAttributes
{
    public class FirstLastNameMustBeDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var authors = (AuthorForCreateDto)validationContext.ObjectInstance;
            if (authors.FirstName == authors.LastName)
            {
                return new ValidationResult("FirstName dan LastName tidak boleh sama",
                    new[] { nameof(AuthorForCreateDto) });
            }

            return ValidationResult.Success;
        }
    }
}
