using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TvDBCtrl.Objects.Models
{
    public class JsonErrors
    {
        [JsonProperty("invalidFilters")]
        List<string>    InvalidFilters          { get; set; }       // Invalid filters passed to route

        [JsonProperty("invalidLanguage")]
        string          InvalidLanguage         { get; set; }       // Invalid language or translation missing

        [JsonProperty("invalidQueryParams")]
        List<string>    InvalidQueryParams      { get; set; }       // Invalid query params passed to route
    }
}
