using System.ComponentModel.DataAnnotations;

namespace LoginSignUpAPI.Models
{
    public class BaseUserModel
    {
        [MaxLength(20), Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [MaxLength(20), Required(ErrorMessage = "FirstName is required")]

        public string LastName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.-]+@[gmail|yandex]+.[a-zA-Z0-9-.]+$",
             ErrorMessage = "Must be a valid email")]
        [StringLength(16,
             ErrorMessage = "Must be between 5 and 50 characters",
             MinimumLength = 5)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255,
            ErrorMessage = "Must be between 8 and 255 characters",
            MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string Password { get; set; }
    }
}
