using System.Collections.Generic;

using TvDBCtrl.Objects.Models;

namespace TvDBCtrl.Objects.Responses
{
    internal class _episodes
    {
        public PagingData               Links   { get; set; }
        public List<Episode>            Data    { get; set; }
        public JsonErrors               Errors  { get; set; }
    }
}
