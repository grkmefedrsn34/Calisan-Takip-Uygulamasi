using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagentment.Application.Request;

namespace TaskManagentment.Application.Validation
{
    public class LoginRequestValidation : AbstractValidator<AccountRequest>
    {
        public LoginRequestValidation()
        {
            this.RuleFor(x => x.Username).NotEmpty()
                .WithMessage("Username is required");
            this.RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
