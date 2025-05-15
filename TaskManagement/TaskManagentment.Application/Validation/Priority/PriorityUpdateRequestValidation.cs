using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Validation.Priority
{
    class PriorityUpdateRequestValidation : AbstractValidator<PriorityUpdateRequest>
    {
        public PriorityUpdateRequestValidation()
        {
            this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition is required");
        }
    }
}
