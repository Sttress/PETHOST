using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETHOST.Domain.Validation
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator() 
        {
            RuleFor(e => e)
                .NotEmpty().WithMessage("A senha é obrigatória!")
                .Matches(@"[A-Z]+").WithMessage("A senha deve conter pelo menos uma letra maiúscula!")
                .Matches(@"[a-z]+").WithMessage("A senha deve conter pelo menos uma letra minuscula!")
                .Matches(@"[0-9]+").WithMessage("A senha deve conter pelo menos um número!")
                .Matches(@"[\!\?\*\.\@\#\$\%\^\&\+\=]+")
                .WithMessage("A senha deve conter pelo menos um caractere especial, sendo : !, ?, *, ., @, #, $, %, ^, &, +, =");
        }

    }
}
