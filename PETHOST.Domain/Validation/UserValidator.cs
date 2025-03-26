using FluentValidation;
using PETHOST.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETHOST.Domain.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(e => e.FirtName)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MinimumLength(3).WithMessage("O nome deve ter mais de 3 caracteres")
                .MaximumLength(70).WithMessage("O nome deve ter menos de 70 caracteres");
            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MinimumLength(3).WithMessage("O nome deve ter mais de 3 caracteres")
                .MaximumLength(70).WithMessage("O nome deve ter menos de 70 caracteres");

            RuleFor(e => e.Password).SetValidator(new PasswordValidator());

            RuleFor(e => e.Phone).SetValidator(new PhoneValidator());
            RuleFor(e => e.Email).SetValidator(new EmailValidator());
        }
    }
}
