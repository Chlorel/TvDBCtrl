using System;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Jwt Token Authentication Information.
    /// </summary>
    public class JwtToken
    {
        /// <summary>
        /// The JWT Authentication Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The Time this token expires.
        /// </summary>
        public DateTime Expires { get; set; }
    }
}
