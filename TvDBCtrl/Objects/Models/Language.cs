namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Language Information for a Language.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// The TVDB id for this language (Unique).
        /// </summary>
        public uint     id              { get; set; }

        /// <summary>
        /// The TVDB abbreviation for this language (Unique).
        /// </summary>
        public string   abbreviation    { get; set; }

        /// <summary>
        /// The TVDB name for this language (Unique).
        /// </summary>
        public string   name            { get; set; }

        /// <summary>
        /// The TVDB englishName for this language (Unique).
        /// </summary>
        public string   englishName     { get; set; }

    }
}
