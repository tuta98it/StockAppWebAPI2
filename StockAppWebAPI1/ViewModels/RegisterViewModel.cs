using System.ComponentModel.DataAnnotations;

namespace StockAppWebAPI11.ViewModels
{
    public class RegisterViewModel
    {
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "You must enter your phone")]
        public string Phone { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
    }
}
