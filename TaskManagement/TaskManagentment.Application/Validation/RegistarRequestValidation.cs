using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Validation
{
    public class RegistarRequestValidation : AbstractValidator<RegistarRequest>
    {
        public RegistarRequestValidation()
        {
            this.RuleFor(x => x.Username).NotEmpty()
                .WithMessage("Username is required");
            this.RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required");
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            this.RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
        }
    }
}
