using PETHOST.Common.Validation;
using PETHOST.Domain.Common;
using PETHOST.Domain.Validation;
using System.ComponentModel.DataAnnotations;


namespace PETHOST.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirtName { get; set; }  = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public User()
        {
            CreatedAt = DateTime.UtcNow;
            Active = false;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new UserValidator();
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
