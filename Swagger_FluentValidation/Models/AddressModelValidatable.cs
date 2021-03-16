using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Swagger_FluentValidation.Data;

namespace Swagger_FluentValidation.Models
{
    public class AddressModelValidatable : IValidatableObject
    {
        [Required]
        [MaxLength(100)]
        public string Line1 { get; set; }

        [MaxLength(100)]
        public string Line2 { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}(-?\d{4})?$")]
        public string Zip { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var stateRepository = (IStateRepository)validationContext.GetService(typeof(IStateRepository));

            var state = stateRepository.GetState(State);

            if (state == null)
            {
                yield return new ValidationResult("Unknown state", new[] { nameof(State) });
            }
        }
    }
}