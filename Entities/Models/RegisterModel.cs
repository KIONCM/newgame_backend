using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }

        public string Email { get; set; }
        [Required(ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; }

        

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }


        public string PofilePicture { get; set; }
    }
}
