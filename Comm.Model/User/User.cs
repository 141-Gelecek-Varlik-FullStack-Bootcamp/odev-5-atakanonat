using System.ComponentModel.DataAnnotations;

namespace Comm.Model.User
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide your name.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Minimum 3 and maximum 50 characters allowed.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide an username.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Minimum 3 and maximum 50 characters allowed.", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please provide your email.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Minimum 3 and maximum 50 characters allowed.", MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a password.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Minimum 3 and maximum 50 characters allowed.", MinimumLength = 3)]
        public string Password { get; set; }
    }
}