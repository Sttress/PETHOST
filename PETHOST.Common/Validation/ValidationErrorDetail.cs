using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETHOST.Common.Validation
{
    public class ValidationErrorDetail
    {
        public string Error { get; init; } = string.Empty;
        public string Detail { get; init; } = string.Empty;

        public static explicit operator ValidationErrorDetail(ValidationFailure validationFailure) => ConvertFrom(validationFailure);

        public static ValidationErrorDetail ConvertFrom(ValidationFailure validationFailure)
        {
            return new ValidationErrorDetail
            {
                Detail = validationFailure.ErrorMessage,
                Error = validationFailure.ErrorCode
            };
        }
    }
}
