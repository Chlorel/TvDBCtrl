using System.Collections.Generic;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Serie Episodes Summary datas.
    /// </summary>
    public class EpisodeSummary
    {
        /// <summary>
        /// The Aired Seasons this Series contains.
        /// </summary>
        public IReadOnlyCollection<string> AiredSeasons { get; set; }

        /// <summary>
        /// The Aired Episodes information.
        /// </summary>
        public string AiredEpisodes { get; set; }

        /// <summary>
        /// The DVD Seasons this Series contains.
        /// </summary>
        public IReadOnlyCollection<string> DVDSeasons { get; set; }

        /// <summary>
        /// The DVD Episodes information.
        /// </summary>
        public string DVDEpisodes { get; set; }
    }
}
