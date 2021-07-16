using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Entities.DataTransfareObjects
{
   public class RegisterUserDTO
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }


        public string PofilePicture { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
