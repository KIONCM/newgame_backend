using System.ComponentModel.DataAnnotations;


namespace Entities.DataTransfareObjects
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is Requird!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Username is Requird!")]
        public string Password { get; set; }
    }
}
