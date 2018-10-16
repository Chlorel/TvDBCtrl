using System;
using Newtonsoft.Json;

using TvDBCtrl.Objects.Converters;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Actor Information for a Series.
    /// </summary>
    public class Acteur
    {
        /// <summary>
        /// The TVDB ID for this Actor (Unique for each Series only).
        /// </summary>
        [JsonProperty("id")]
        public uint                         ActorID         { get; set; }

        /// <summary>
        /// The Series this Actor is in relation to.
        /// </summary>
        [JsonProperty("seriesId")]
        public uint                         SeriesID        { get; set; }

        /// <summary>
        /// The Name of the Actor.
        /// </summary>
        [JsonProperty("name")]
        public string                       Name            { get; set; }

        /// <summary>
        /// The Actor's role in this Series.
        /// </summary>
        [JsonProperty("role")]
        public string                       Role            { get; set; }

        /// <summary>
        /// The priority of this Actor in the order of the Actors list.
        /// </summary>
        [JsonProperty("sortOrder")]
        public int                          SortOrder       { get; set; }

        /// <summary>
        /// The Image Url for this Actor in this Series.
        /// </summary>
        [JsonProperty("image")]
        public string                       Image           { get; set; }

        /// <summary>
        /// The TVDB User who provided the Image.
        /// </summary>
        [JsonProperty("imageAuthor")]
        public uint?                        ImageAuthor     { get; set; }

        /// <summary>
        /// The Date this image was added to TVDB.
        /// </summary>
        [JsonProperty("imageAdded")]
        [JsonConverter(typeof(StringDateConv))]
        public DateTime?                    ImageAdded      { get; set; }

        /// <summary>
        /// The date this Actor Information was last updated.
        /// </summary>
        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(StringDateConv))]
        public DateTime?                    LastUpdated     { get; set; }
    }
}
