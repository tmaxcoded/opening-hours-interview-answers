using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Models.validators
{
    public class WorkingHoursValueTypeValidator: AbstractValidator<WorkingHoursValueType>
    {
        public WorkingHoursValueTypeValidator()
        {
            RuleFor(x => x.type).NotNull()
                .WithMessage("opening hours type cannot be null")
                .NotEmpty().WithMessage("opening hours type cannot be empty");
            RuleFor(x => x.value)
                .NotNull()
                .WithMessage("opening hours value cannot be null")
                .NotEmpty()
                .WithMessage("opening hours value cannot be empty")
                .LessThanOrEqualTo(86399)
                .WithMessage($"maximum value must be {86399}");
           
        }
    }
}
