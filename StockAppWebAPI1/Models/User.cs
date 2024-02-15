using System.ComponentModel.DataAnnotations;

namespace StockAppWebAPI1.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 100 characters")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage = "Password is required")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 200 characters")]
        public string HashedPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "Full name cannot exceed 255 characters")]
        public String? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? Country { get; set; }

    }
}
