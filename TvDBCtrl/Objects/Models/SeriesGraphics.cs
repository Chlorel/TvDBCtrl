using System;
using System.Collections.Generic;

namespace TvDBCtrl.Objects.Models
{
    public class SeriesGraphics
    {

        /// <summary>
        /// The top rated Poster Image Url string for this Series.
        /// </summary>
        public string                       Poster          { get; set; }

        /// <summary>
        /// Full Posters for this Serie.
        /// </summary>
        public IReadOnlyList<Picture>       Posters         { get; set; }

        /// <summary>
        /// The top rated Fanart Image Url string for this Serie.
        /// </summary>
        public string                       Fanart          { get; set; }

        /// <summary>
        /// Full Fanarts for this Serie.
        /// </summary>
        public IReadOnlyList<Picture>       Fanarts         { get; set; }

        /// <summary>
        /// The top rated Season Banner Image Url string for this Serie.
        /// </summary>
        public string                       Season          { get; set; }

        /// <summary>
        /// Full Season Banners for this Serie.
        /// </summary>
        public IReadOnlyList<Picture>       Seasons         { get; set; }

        /// <summary>
        /// The top rated SeasonWide Poster Image Url string for this Serie.
        /// </summary>
        public string                       SeasonWide      { get; set; }

        /// <summary>
        /// Full Season Posters for this Serie.
        /// </summary>
        public IReadOnlyList<Picture>       SeasonWides     { get; set; }

        /// <summary>
        /// The top rated Serie Picture Url string for this Serie.
        /// </summary>
        public string                       Serie           { get; set; }

        /// <summary>
        /// Full Serie Pictures for this Serie.
        /// </summary>
        public IReadOnlyList<Picture>       Series          { get; set; }
    }
}
