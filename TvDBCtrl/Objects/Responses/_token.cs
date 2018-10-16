using System;
using Newtonsoft.Json;
using TvDBCtrl.Objects.Models;

namespace TvDBCtrl.Objects.Responses
{
    internal class _token
    {
        public JwtToken Data => new JwtToken
        {
            Token   = Token,
            Expires = Expires
        };

        [JsonIgnore]
        private string __token;

        public string   Token       { get { return __token; } set { __token = value; Expires = DateTime.Now.AddHours(24); } }
        public DateTime Expires     { get; private set; }
    }
}
