using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Validation.Priority
{
    public class PriorityCreateRequestValidation : AbstractValidator<PriorityCreateRequest>
    {
        public PriorityCreateRequestValidation()
        {
            RuleFor(x => x.Definition)
                .NotEmpty().WithMessage("Definition is required")
                .MinimumLength(3).WithMessage("Definition must be at least 3 characters long")
                .MaximumLength(50).WithMessage("Definition must not exceed 50 characters");
        }
    }
}
