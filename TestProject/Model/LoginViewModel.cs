using System.ComponentModel.DataAnnotations;

namespace TestProject.Model
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}
