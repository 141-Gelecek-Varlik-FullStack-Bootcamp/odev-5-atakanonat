using System.ComponentModel.DataAnnotations;

namespace Comm.Model.User
{
    public class UserLogin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide your username.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Minimum 3 and maximum 50 characters allowed.", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide your password.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Minimum 3 and maximum 50 characters allowed.", MinimumLength = 3)]
        public string Password { get; set; }
    }
}