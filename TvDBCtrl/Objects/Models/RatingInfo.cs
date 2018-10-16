using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Rating information from TVDB.
    /// </summary>
    public class RatingInfo
    {
        /// <summary>
        /// The average rating of the Show.
        /// </summary>
        public double?  Average     { get; set; }
        /// <summary>
        /// The number of ratings for the show.
        /// </summary>
        public ulong?   Count       { get; set; }
    }
}
