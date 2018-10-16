using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TvDBCtrl.Objects.Converters;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Episode Information.
    /// </summary>
    public class Episode
    {

        /// <summary>
        /// The Absolute Episode Number for the entire Series.
        /// </summary>
        [JsonProperty("absoluteNumber")]
        public uint?                        AbsoluteEpisodeNumber   { get; set; }

        /// <summary>
        /// The Episode Number of this Episode in the Season.
        /// </summary>
        [JsonProperty("airedEpisodeNumber")]
        public uint                         EpisodeNumber           { get; set; }

        /// <summary>
        /// The Season Number of this Episode.
        /// </summary>
        [JsonProperty("airedSeason")]
        public uint                         SeasonNumber            { get; set; }

        /// <summary>
        /// Was aired after the season
        /// </summary>
        [JsonProperty("airsAfterSeason")]
        public uint?                        airsAfterSeason         { get; set; }

        /// <summary>
        /// Was aired before this episode
        /// </summary>
        [JsonProperty("airsBeforeEpisode")]
        public uint?                        airsBeforeEpisode       { get; set; }

        /// <summary>
        /// Was aired before the season
        /// </summary>
        [JsonProperty("airsBeforeSeason")]
        public uint?                        airsBeforeSeason        { get; set; }

        /// <summary>
        /// Director for this episode
        /// </summary>
        [JsonProperty("director")]
        public string                       director                { get; set; }

        /// <summary>
        /// List of Directors for the selected episode.
        /// </summary>
        [JsonProperty("directors")]
        public IReadOnlyCollection<string>  directors               { get; set; }

        /// <summary>
        /// Chapitre du DVD de cet episode
        /// </summary>
        [JsonProperty("dvdChapter")]
        public uint?                        dvdChapter              { get; set; }

        /// <summary>
        /// Titre du DVD de cet episode.
        /// </summary>
        [JsonProperty("dvdDiscid")]
        public string                       dvdDiscid               { get; set; }
        /// <summary>
        /// The Episode Number of this Episode in the DVD Season.
        /// </summary>
        [JsonProperty("dvdEpisodeNumber")]
        public uint?                        DVDEpisodeNumber        { get; set; }

        /// <summary>
        /// The Season number of this Episode on DVD.
        /// </summary>
        [JsonProperty("dvdSeason")]
        public uint?                        DVDSeason               { get; set; }

        /// <summary>
        /// The Title of this Episode.
        /// </summary>
        [JsonProperty("episodeName")]
        public string                       EpisodeName             { get; set; }

        /// <summary>
        /// Image file for the selected episode.
        /// </summary>
        [JsonProperty("filename")]
        public string                       Filename                { get; set; }

        /// <summary>
        /// The Date this Episode first aired.
        /// </summary>
        [JsonProperty("firstAired")]
        [JsonConverter(typeof(StringDateConv))]
        public DateTime?                    FirstAired              { get; set; }

        /// <summary>
        /// List of Guest Stars from the selected episode.
        /// </summary>
        [JsonProperty("guestStars")]
        public IReadOnlyCollection<string>  GuestStars              { get; set; }

        /// <summary>
        /// The TVDB ID for this Episode.
        /// </summary>
        [JsonProperty("id")]
        public uint                         EpisodeID               { get; set; }

        /// <summary>
        /// Episode IMDB Id.
        /// </summary>
        [JsonProperty("imdbId")]
        public string                       IMDBId                  { get; set; }

        /// <summary>
        /// The Date this Episode's information was last updated.
        /// </summary>
        [JsonProperty("lastUpdated")]
        [JsonConverter(typeof(EpochTimeConv))]
        public DateTimeOffset?              LastUpdated             { get; set; }

        /// <summary>
        /// User that updated this episode
        /// </summary>
        [JsonProperty("lastUpdatedBy")]
        public string                       LastUpdatedBy           { get; set; }

        /// <summary>
        /// The overview of this Episode.
        /// </summary>
        [JsonProperty("overview")]
        public string                       Overview                { get; set; }

        /// <summary>
        /// Production code for this episode
        /// </summary>
        [JsonProperty("productionCode")]
        public string                       ProductionCode          { get; set; }

        /// <summary>
        /// The Series this Episode belongs to.
        /// </summary>
        [JsonIgnore]
        public uint                         SeriesID                { get; set; }

        /// <summary>
        /// Show Url
        /// </summary>
        [JsonProperty("showUrl")]
        public string                       ShowUrl                 { get; set; }

        /// <summary>
        /// Episode Rating.
        /// </summary>
        [JsonProperty("siteRating")]
        public double                       SiteRating              { get; set; }

        /// <summary>
        /// Episode Rating counts
        /// </summary>
        [JsonProperty("siteRatingCount")]
        public uint?                        SiteRatingCount         { get; set; }

        /// <summary>
        /// No Idea on what this is
        /// </summary>
        [JsonProperty("thumbAdded")]
        public string                       thumbAdded              { get; set; }

        /// <summary>
        /// User ID from user that added the thumb
        /// </summary>
        [JsonProperty("thumbAuthor")]
        public uint?                        thumbAuthor             { get; set; }

        /// <summary>
        /// Image Height.
        /// </summary>
        [JsonProperty("thumbHeight")]
        public string                       thumbHeight             { get; set; }

        /// <summary>
        /// Image Width.
        /// </summary>
        [JsonProperty("thumbWidth")]
        public string                       thumbWidth              { get; set; }

        /// <summary>
        /// List of Writers from the selected episode.
        /// </summary>
        [JsonProperty("writers")]
        public IReadOnlyCollection<string>  Writers                 { get; set; }
        
        [JsonProperty("SeriesID")]
        private string _SeriesID
        {
            get { return SeriesID.ToString(); }
            set { SeriesID = Convert.ToUInt32(value); }
        }
    }
}
