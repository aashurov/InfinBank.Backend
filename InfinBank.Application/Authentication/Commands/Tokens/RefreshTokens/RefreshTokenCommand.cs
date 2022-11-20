﻿using MediatR;

namespace InfinBank.Application.Authentication.Commands.Tokens.RefreshTokens
{
    public class RefreshTokenCommand : IRequest
    {
        /// <summary>
        ///
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string JwtId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsRevoked { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime AddedDateTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime ExpiryDateTime { get; set; }
    }
}