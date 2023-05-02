using System.ComponentModel.DataAnnotations;

namespace VideoClubA.Web.Areas.Register.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public RegisterViewModel()
        {
            
        }

        public RegisterViewModel(string email, string password, 
            string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }

}
