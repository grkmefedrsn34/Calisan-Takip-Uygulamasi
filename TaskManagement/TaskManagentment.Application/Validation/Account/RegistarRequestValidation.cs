using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Validation.Account
{
    public class RegistarRequestValidation : AbstractValidator<RegistarRequest>
    {
        public RegistarRequestValidation()
        {
            RuleFor(x => x.Username).NotEmpty()
                .WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x=> x.Password).Equal(x => x.ConfirmPassword)
                .WithMessage("Password and Confirm Password must be same");
        }
    }
}
