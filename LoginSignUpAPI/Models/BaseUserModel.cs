using System.ComponentModel.DataAnnotations;

namespace LoginSignUpAPI.Models
{
    public class BaseUserModel
    {
        [MaxLength(20), Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [MaxLength(20), Required(ErrorMessage = "LastName is required")]

        public string LastName { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[gmail|yandex]+.[a-zA-Z0-9-.]+$",
                    ErrorMessage = "Must be a valid email")]
        [StringLength(16,
                    ErrorMessage = "Must be between 5 and 50 characters",
                    MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
