using System;
using Newtonsoft.Json;

using TvDBCtrl.Objects.Converters;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Images Count summary
    /// </summary>
    public class PicturesSummary
    {
        /// <summary>
        /// Every fanart count
        /// </summary>
        public uint     fanart          { get; set; }

        /// <summary>
        /// Every poster count
        /// </summary>
	    public uint     poster          { get; set; }

        /// <summary>
        /// Every season poster count
        /// </summary>
        public uint     season          { get; set; }

        /// <summary>
        /// Everey season banner count
        /// </summary>
        public uint     seasonwide      { get; set; }

        /// <summary>
        /// No idea on what is in 
        /// </summary>
        public uint     series          { get; set; }

    }
}
