﻿using System.ComponentModel.DataAnnotations;

namespace InfinBank.WebApi.Models.AuthManager
{
    /// <summary>
    ///
    /// </summary>
    public class TokenRequest
    {
        /// <summary>
        ///
        /// </summary>
        [Required]
        public string Token { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Required]
        public string RefreshToken { get; set; }
    }
}