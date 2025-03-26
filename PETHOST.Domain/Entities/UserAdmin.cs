using PETHOST.Common.Validation;
using PETHOST.Domain.Common;
using PETHOST.Domain.Validation;
using System;


namespace PETHOST.Domain.Entities
{
    public class UserAdmin : BaseEntity
    {
        public string UserName {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public UserAdmin()
        {
            CreatedAt = DateTime.UtcNow;
            Active = false;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new UserAdminValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void Activate()
        {
            Active = true;
            UpdatedAt = DateTime.UtcNow;
        }


    }
}
