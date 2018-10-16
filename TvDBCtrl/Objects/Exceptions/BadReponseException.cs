﻿using System;
using System.Net;

namespace TvDBCtrl.Objects.Exceptions
{
    /// <summary>
    /// The TVDB API responded with an Error.
    /// </summary>
    public class BadResponseException : Exception
    {
        /// <summary>
        /// Http Status Code of Response.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        internal BadResponseException(HttpStatusCode statusCode, string message = "Bad response", Exception inner = null)
            : base(message, inner)
        {
            StatusCode = statusCode;
        }
    }
}
