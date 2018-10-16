using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using TvDBCtrl.Enums;
using TvDBCtrl.Objects.Converters;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Series Information.
    /// </summary>
    public class SeriesFull
    {
        /// <summary>
        /// The date this show was added to TVDB.
        /// </summary>
        [JsonProperty("added")]
        [JsonConverter(typeof(StringDateConv))]
        public DateTime?                        Added           { get; set; }

        /// <summary>
        /// The day(s) this show Airs.
        /// </summary>
        [JsonProperty("airsDayOfWeek")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AirDay?                          AirDay          { get; set; }

        /// <summary>
        /// The time of the Day that this series airs on.
        /// </summary>
        [JsonProperty("airsTime")]
        [JsonConverter(typeof(TimeSpanConv))]
        public TimeSpan?                        AirTime         { get; set; }

        /// <summary>
        /// The Aliases for the Series Name.
        /// </summary>
        [JsonProperty("aliases")]
        public List<string>                     Aliases         { get; set; }

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
        /// The Genres that this Series belongs to.
        /// </summary>
        [JsonProperty("genre")]
        public List<string>                     Genres          { get; set; }

        /// <summary>
        /// The TVDB ID for the Series.
        /// </summary>
        [JsonProperty("id")]
        public uint                             TvDBID          { get; set; }

        /// <summary>
        /// The IMDB ID for the Series.
        /// </summary>
        [JsonProperty("imdbId")]
        public string                           IMDBID          { get; set; }

        /// <summary>
        /// The date this show information was last updated.
        /// </summary>
        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(EpochTimeConv))]
        public DateTimeOffset?                  LastUpdated     { get; set; }

        /// <summary>
        /// The Network this Series belongs to.
        /// </summary>
        [JsonProperty("network")]
        public string                           Network         { get; set; }

        /// <summary>
        /// The Network ID that this Series belongs to.
        /// </summary>
        [JsonProperty("networkId")]
        public string                           NetworkID       { get; set; }

        /// <summary>
        /// The Overview of this Series.
        /// </summary>
        [JsonProperty("overview")]
        public string                           Overview        { get; set; }

        /// <summary>
        /// The Content Rating of this Series, in US format.
        /// </summary>
        [JsonProperty("rating")]
        public string                           ContentRating   { get; set; }

        /// <summary>
        /// The time this show runs for in minutes.
        /// </summary>
        [JsonProperty("runtime")]
        public uint?                            Runtime         { get; set; }

        /// <summary>
        /// Network Serie ID in string format
        /// </summary>
        [JsonProperty("seriesId")]
        public string                           SerieID         { get; set; }

        /// <summary>
        /// The Name of the Series.
        /// </summary>
        [JsonProperty("seriesName")]
        public string                           SeriesName      { get; set; }

        /// <summary>
        /// The average rating for this Series on TVDB.
        /// </summary>
        [JsonProperty("siteRating")]
        public double?                          SiteRating      { get; set; }

        /// <summary>
        /// The number of ratings of this Series on TVDB.
        /// </summary>
        [JsonProperty("siteRatingCount")]
        public ulong?                           SiteRatingCount { get; set; }

        /// <summary>
        /// Allmost any field i dont know what is in !
        /// </summary>
        [JsonProperty("slug")]
        public string                           Slug            { get; set; }

        /// <summary>
        /// The current Status of this Series.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status?                          Status          { get; set; }

        /// <summary>
        /// Zap2it ID for this serie
        /// </summary>
        [JsonProperty("zap2itId")]
        public string                           Zap2itId        { get; set; }

        /// <summary>
        /// Summary infos for this serie
        /// </summary>
        public SeriesSummary                     Summary         { get; set; }

        /// <summary>
        /// All Actors in this serie
        /// </summary>
        public List<Acteur>                     Acteurs         { get; set; }

        /// <summary>
        /// Requested Episode list
        /// </summary>
        public List<Episode>                    Episodes        { get; set; }

        /// <summary>
        /// All Graphics for this serie.
        /// </summary>
        public SeriesGraphics                    Graphics        { get; set; }
    }
}
