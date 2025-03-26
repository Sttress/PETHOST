using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETHOST.Domain.Validation
{
    public class PhoneValidator : AbstractValidator<string>
    {
        public PhoneValidator() 
        {
            RuleFor(e => e)
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("O número de telefone não é válido!");

        }
    }
}
