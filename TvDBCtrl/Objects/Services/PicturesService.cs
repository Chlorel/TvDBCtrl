using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TvDBCtrl.Client;
using TvDBCtrl.Enums;
using TvDBCtrl.Objects.Models;
using TvDBCtrl.Objects.Responses;

namespace TvDBCtrl.Objects.Services
{
    /// <summary>
    /// Methods relating to Graphics Information ( Fanart / Poster / Banner ).
    /// </summary>
    public class PicturesService : BaseService
    {
        private Language UserLanguage;
        internal PicturesService(Configuration Config) : base(Config)
        {
        }

        /// <summary>
        /// Gets the Pictures froms specified Type for this Series.
        /// </summary>
        /// <param name="SeriesID">Series ID to get Pictures</param>
        /// <param name="Type">Type of Pictures to get</param>
        /// <returns>List of found Pictures</returns>
        public async Task<List<Picture>> GetPictures ( uint SeriesID, Graphics Type )
        {
            UserLanguage                        = ApiConfig.UserLanguage;
            string ImgQuery                     = "";

            switch (Type)
            {
                case Graphics.Fanart:
                    ImgQuery = $"/series/{SeriesID}/images/query?keyType=fanart";
                    break;

                case Graphics.Posters:
                    ImgQuery = $"/series/{SeriesID}/images/query?keyType=poster";
                    break;

                case Graphics.Season:
                    ImgQuery = $"/series/{SeriesID}/images/query?keyType=season";
                    break;

                case Graphics.SeasonWide:
                    ImgQuery = $"/series/{SeriesID}/images/query?keyType=seasonwide";
                    break;

                case Graphics.Series:
                    ImgQuery = $"/series/{SeriesID}/images/query?keyType=series";
                    break;
            }

            ApiConfig.UserLanguage              = ApiConfig.DefaultLanguage;
            HttpResponseMessage     response    = await GetAsync(ApiConfig.BaseUrl + ImgQuery);
            ApiConfig.UserLanguage              = UserLanguage;
            string                  jsonData    = await response.Content.ReadAsStringAsync();
            List<Picture>           pictures    = JsonConvert.DeserializeObject<_pictures>(jsonData).Data;
            JsonErrors              errors      = JsonConvert.DeserializeObject<_jsonerrors>(jsonData).Errors;

            return pictures.Any() ? pictures : null;
        }

        /// <summary>
        /// Gets the images summary for this Series.
        /// </summary>
        /// <param name="SeriesID">Series to get summary for.</param>
        /// <returns>Picture summary list</returns>
        public async Task<PicturesSummary> GetPicturesSummary (uint SeriesID)
        {
            UserLanguage                        = ApiConfig.UserLanguage;
            ApiConfig.UserLanguage              = ApiConfig.DefaultLanguage;
            HttpResponseMessage     response    = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/images");
            ApiConfig.UserLanguage              = UserLanguage;
            string                  jsonData    = await response.Content.ReadAsStringAsync();
            PicturesSummary         result      = JsonConvert.DeserializeObject<_picturessum>(jsonData).Data;
            JsonErrors              errors      = JsonConvert.DeserializeObject<_jsonerrors>(jsonData).Errors;

            return result;
        }
    }
}
