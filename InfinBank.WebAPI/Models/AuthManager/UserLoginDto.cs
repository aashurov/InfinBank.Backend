using System.ComponentModel.DataAnnotations;

namespace InfinBank.WebApi.Models.AuthManager
{
    /// <summary>
    ///
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        ///
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}