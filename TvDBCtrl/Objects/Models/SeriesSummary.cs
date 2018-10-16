using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

using TvDBCtrl.Enums;
using TvDBCtrl.Objects.Converters;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Basic Series Information for a Search.
    /// </summary>
    public class SeriesSummary
    {
        /// <summary>
        /// The Aliases for the Series Name.
        /// </summary>
        [JsonProperty("aliases")]
        public IReadOnlyCollection<string>      Aliases         { get; set; }

        /// <summary>
        /// The Banner Image Url string for this Series.
        /// </summary>
        [JsonProperty("banner")]
        public string                           Banner          { get; set; }

        /// <summary>
        /// The date this show first aired.
        /// </summary>
        [JsonProperty("firstAired")]
        [JsonConverter(typeof(StringDateConv))]
        public DateTime?                        FirstAired      { get; set; }

        /// <summary>
        /// The TVDB ID for the Series.
        /// </summary>
        [JsonProperty("id")]
        public uint                             TvDBID          { get; set; }

        /// <summary>
        /// The Network this Series belongs to.
        /// </summary>
        [JsonProperty("network")]
        public string                           Network         { get; set; }

        /// <summary>
        /// The Overview of this Series.
        /// </summary>
        [JsonProperty("overview")]
        public string                           Overview        { get; set; }

        /// <summary>
        /// The Name of the Series.
        /// </summary>
        [JsonProperty("seriesName")]
        public string                           SeriesName      { get; set; }

        /// <summary>
        /// Slug (once again no idea on what it is
        /// </summary>
        [JsonProperty("slug")]
        public string                           Slug            { get; set; }

        /// <summary>
        /// The current Status of this Series.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status?                          Status          { get; set; }
    }
}
