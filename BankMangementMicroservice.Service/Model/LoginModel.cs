using System.ComponentModel.DataAnnotations;

namespace BankMangementMicroservice.Service.Model
{
    public class LoginModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Password cannot exceed 20 characters.")]
        public string Password { get; set; }
    }
}
