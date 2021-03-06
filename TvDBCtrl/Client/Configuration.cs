﻿using TvDBCtrl.Objects.Models;
namespace TvDBCtrl.Client
{
    /// <summary>
    /// The Configuration information for the API.
    /// </summary>
    internal class Configuration
    {
        /// <summary>
        /// The JWT Token for this Configuration.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The Base Url for the API.
        /// </summary>
        public string BaseUrl { get; }

        public Language DefaultLanguage { get; private set; }

        /// <summary>
        /// Language for request answers.
        /// </summary>
        public Language UserLanguage { get; set; }

        /// <summary>
        /// Sets the JWT Token for this Client.
        /// </summary>
        /// <param name="Token">JWT Token</param>
        public void SetToken(string Token)
        {
            this.Token = $"Bearer {Token}";
        }

        /// <summary>
        /// Set the Language for request answers.
        /// </summary>
        public void SetLanguage(Language Langue)
        {
            this.UserLanguage = Langue;
        }

        public void SetDefaultLanguage (Language Langue)
        {
            this.DefaultLanguage = Langue;
        }

        /// <summary>
        /// The Constructor for <see cref="Configuration"/>.
        /// </summary>
        /// <param name="Token">JWT Token</param>
        /// <param name="BaseUrl">The Base Url for the API</param>
        public Configuration(string Token, string BaseUrl)
        {
            if (!string.IsNullOrWhiteSpace(Token))
                SetToken(Token);
            this.BaseUrl = BaseUrl;
        }
    }
}
