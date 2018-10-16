using System;

namespace TvDBCtrl.Objects.Models
{
    /// <summary>
    /// Information about a Series being updated.
    /// </summary>
    public class Update
    {
        internal Update()
        {
        }

        /// <summary>
        /// Series ID that was updated.
        /// </summary>
        public uint     Id          { get; set; }

        /// <summary>
        /// The Time it was updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}
