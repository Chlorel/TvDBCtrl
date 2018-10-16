using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDBCtrl.Enums
{
    /// <summary>
    /// Determines Query Type for Searching a serie.
    /// </summary>
    public enum QueryType
    {
        Name    = 0x01,
        ImDB    = 0x02,
        Zap2it  = 0x04,
        TvDB    = 0x08
    }
}
