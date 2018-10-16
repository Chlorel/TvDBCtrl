using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvDBCtrl.Enums
{
    public enum Range
    {
        Serie           = 0x01,
        Acteurs         = 0x02,
        ImgPosters      = 0x04,
        ImgSeason       = 0x08,
        ImgSeasonWide   = 0x10,
        ImgFanart       = 0x20,
        ImgSeries       = 0x40,
        ImgAll          = 0x7C
    }
}
