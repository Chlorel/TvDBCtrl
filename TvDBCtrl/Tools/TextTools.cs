using System.Text;
using System.Globalization;

namespace TvDBCtrl.Tools
{
    public static class TextTools
    {
        /// <summary>
        /// Remove any special char string 
        /// </summary>
        /// <param name="stIn">String to cleanup</param>
        /// <returns>cleaned string</returns>
        public static string RemoveDiacritics(string stIn)
        {
            string          stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder   sb      = new StringBuilder();

            foreach (char t in stFormD)
            {
                UnicodeCategory uc  = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
    }
}
