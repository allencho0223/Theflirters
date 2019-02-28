using System.ComponentModel.DataAnnotations;

namespace D8M8.API.Dtos
{
    // Data Transfer Object
    public class UserForRegisterDto
    {
        // Data Annotations
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }
        
    }
}