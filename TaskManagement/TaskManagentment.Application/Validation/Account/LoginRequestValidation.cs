using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Validation.Account
{
    public class LoginRequestValidation : AbstractValidator<AccountRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(x => x.Username).NotEmpty()
                .WithMessage("Username is required");
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
