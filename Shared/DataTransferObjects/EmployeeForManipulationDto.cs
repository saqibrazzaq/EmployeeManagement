using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee Name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? Name { get; init; }
        [Range(18, int.MaxValue, ErrorMessage = "Age is a required field and must be 18 or above.")]
        public int Age { get; init; }
        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(ErrorMessage = "Maximum length for the position is 20 characters.")]
        public string? Position { get; init; }
    }
}
