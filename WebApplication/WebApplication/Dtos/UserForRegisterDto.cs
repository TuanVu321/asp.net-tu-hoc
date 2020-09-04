using System.ComponentModel.DataAnnotations;

namespace WebApplication.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(8,MinimumLength = 4,ErrorMessage = "You must specify password between 4-8 chracters")]
        public string Password { get; set; }
    }
}