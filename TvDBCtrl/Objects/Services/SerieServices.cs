using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TvDBCtrl.Client;
using TvDBCtrl.Objects.Models;
using TvDBCtrl.Objects.Requests;
using TvDBCtrl.Objects.Responses;
using TvDBCtrl.Enums;
using TvDBCtrl.Objects.Services;

namespace TvDBCtrl.Objects.Services
{
    /// <summary>
    /// Methods relating to fetching Series Information.
    /// </summary>
    public class SeriesService : BaseService
    {
        private             Language            UserLanguage;
        private readonly    ActeurService       Casting;
        private readonly    PicturesService     Pictures;

        internal SeriesService(Configuration Config) : base(Config)
        {
            Casting         = new ActeurService(Config);
            Pictures        = new PicturesService(Config);
        }

        /// <summary>
        /// Try to find a Serie by Query
        /// </summary>
        /// <param name="query">Query to find the needed Serie</param>
        /// <param name="QType">Type of Query data Name / TvDBID / ImDBID / Zap2ItID</param>
        /// <returns>List of found matching Series</returns>
        public async Task<List<SeriesSummary>> FindSeries (string query, QueryType QType = QueryType.Name)
        {
            List<SeriesSummary> result      = new List<SeriesSummary>();
            UserLanguage                    = ApiConfig.UserLanguage;
            string ToSearch                 = "";

            switch (QType)
            {
                case QueryType.Name:
                    ToSearch            = $"/search/series?name={query}";
                    result              = await QuerySeries(ToSearch);
                    break;
                case QueryType.ImDB:
                    ToSearch            = $"/search/series?imdbId={query}";
                    result              = await QuerySeries(ToSearch);
                    break;
                case QueryType.Zap2it:
                    ToSearch            = $"/search/series?zap2itId={query}";
                    result              = await QuerySeries(ToSearch);
                    break;
                case QueryType.TvDB:
                    SeriesFull serie    = await GetSerieByID(uint.Parse(query));
                    result.Add(serie.Summary);
                    break;
            }
            return result;
        }

        /// <summary>
        /// Search for Series based on everything (ImDB / Zap2It / Name )
        /// </summary>
        /// <param name="ToSearch">qualified query string</param>
        /// <returns>Collection of series</returns>
        private async Task<List<SeriesSummary>> QuerySeries ( string ToSearch )
        {
            List<SeriesSummary> Summaries   = new List<SeriesSummary>();
            List<SeriesSummary> SummaryUL   = new List<SeriesSummary>();
            List<SeriesSummary> SummaryDL   = new List<SeriesSummary>();

            HttpResponseMessage     responseUL  = await GetAsync(ApiConfig.BaseUrl + ToSearch);
            string                  jsonDataUL  = await responseUL.Content.ReadAsStringAsync();
            _seriesum               resultUL    = JsonConvert.DeserializeObject<_seriesum>(jsonDataUL);
            JsonErrors              errorsUL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataUL).Errors;
            SummaryUL.AddRange(resultUL.Data);

            if (!InDefaultLanguage())
            {
                ApiConfig.UserLanguage          = ApiConfig.DefaultLanguage;
                HttpResponseMessage responseDL  = await GetAsync(ApiConfig.BaseUrl + ToSearch);
                string              jsonDataDL  = await responseDL.Content.ReadAsStringAsync();
                _seriesum           resultDL    = JsonConvert.DeserializeObject<_seriesum>(jsonDataDL);
                JsonErrors          errorsDL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataDL).Errors;
                ApiConfig.UserLanguage          = UserLanguage;
                SummaryDL.AddRange(resultDL.Data);
            }

            Summaries = MergeSummaryInfos
                (
                SummaryUL.OrderBy(item => item.TvDBID).ToList(),
                SummaryDL.OrderBy(item => item.TvDBID).ToList()
                );

            return Summaries;
        }

        /// <summary>
        /// Get a Serie with the summary by specified ID
        /// </summary>
        /// <param name="SerieID">Serie ID from the needed serie</param>
        /// <returns>The needed serie if found</returns>
        private async Task<SeriesFull> GetSerieByID(uint SerieID)
        {
            SeriesFull              seriesDL;
            JsonErrors              errorsDL;

            UserLanguage                        = ApiConfig.UserLanguage;
            HttpResponseMessage     responseUL  = await GetAsync(ApiConfig.BaseUrl + $"/series/{SerieID}");
            string                  jsonDataUL  = await responseUL.Content.ReadAsStringAsync();
            SeriesFull              seriesUL    = JsonConvert.DeserializeObject<_seriefull>(jsonDataUL).Data;
            SeriesSummary           summaryUL   = JsonConvert.DeserializeObject<_serie1sum>(jsonDataUL).Data;
            JsonErrors              errorsUL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataUL).Errors;
            seriesUL.Summary                    = summaryUL;

            if (!InDefaultLanguage())
            {
                ApiConfig.UserLanguage          = ApiConfig.DefaultLanguage;
                HttpResponseMessage responseDL  = await GetAsync(ApiConfig.BaseUrl + $"/series/{SerieID}");
                string              jsonDataDL  = await responseDL.Content.ReadAsStringAsync();
                seriesDL                        = JsonConvert.DeserializeObject<_seriefull>(jsonDataDL).Data;
                SeriesSummary       summaryDL   = JsonConvert.DeserializeObject<_serie1sum>(jsonDataDL).Data;
                errorsDL                        = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataDL).Errors;
                ApiConfig.UserLanguage          = UserLanguage;
                seriesDL.Summary                = summaryDL;

                if (string.IsNullOrEmpty(seriesUL.SeriesName))
                {
                    seriesUL.SeriesName         = seriesDL.SeriesName;
                    seriesUL.Summary.SeriesName = seriesDL.Summary.SeriesName;
                }
                if (string.IsNullOrEmpty(seriesUL.Overview))
                {
                    seriesUL.Overview           = seriesDL.Overview;
                    seriesUL.Summary.Overview   = seriesDL.Summary.Overview;
                }
            }

            return seriesUL;
        }

        /// <summary>
        /// Gets Series Information for the Series ID.
        /// </summary>
        /// <param name="SeriesID">Series ID of Series</param>
        /// <param name="Range">Range of elements to include</param>
        /// <returns>Series Information</returns>
        public async Task<SeriesFull> GetSeries(uint SeriesID, Range SRange = Range.Serie)
        {
            SeriesGraphics  SGrapics        = new SeriesGraphics();
            PicturesSummary GCount          = new PicturesSummary();
            GCount                          = await Pictures.GetPicturesSummary(SeriesID);

            SeriesFull      Serie           = await GetSerieByID(SeriesID);

            if (Serie != null)
            {
                if (SRange.HasFlag(Range.Acteurs))
                {
                    Serie.Acteurs = await Casting.GetActors(SeriesID);
                }

                if (SRange.HasFlag(Range.ImgPosters))
                {
                    if (GCount.poster > 0)
                    {
                        SGrapics.Posters = await Pictures.GetPictures(SeriesID, Graphics.Posters);

                        Picture poster = SGrapics.Posters.OrderByDescending(item => item.RatingsInfos.Average)
                                                        .ThenByDescending(item => item.RatingsInfos.Count)
                                                        .ThenByDescending(item => item.LanguageID)
                                                        .FirstOrDefault();
                        SGrapics.Poster = poster?.FileName;
                    }
                    else
                    {
                        SGrapics.Posters = new List<Picture>();
                        SGrapics.Poster = "";
                    }
                }

                if (SRange.HasFlag(Range.ImgFanart))
                {
                    if (GCount.fanart > 0)
                    {
                        SGrapics.Fanarts = await Pictures.GetPictures(SeriesID, Graphics.Fanart);

                        Picture fanart = SGrapics.Fanarts.OrderByDescending(item => item.RatingsInfos.Average)
                                                        .ThenByDescending(item => item.RatingsInfos.Count)
                                                        .ThenByDescending(item => item.LanguageID)
                                                        .FirstOrDefault();
                        SGrapics.Fanart = fanart?.FileName;
                    }
                    else
                    {
                        SGrapics.Fanarts = new List<Picture>();
                        SGrapics.Fanart = "";
                    }
                }

                if (SRange.HasFlag(Range.ImgSeason))
                {
                    if (GCount.season > 0)
                    {
                        SGrapics.Seasons = await Pictures.GetPictures(SeriesID, Graphics.Season);

                        Picture season = SGrapics.Seasons.OrderByDescending(item => item.RatingsInfos.Average)
                                                        .ThenByDescending(item => item.RatingsInfos.Count)
                                                        .ThenByDescending(item => item.LanguageID)
                                                        .FirstOrDefault();
                        SGrapics.Season = season?.FileName;
                    }
                    else
                    {
                        SGrapics.Seasons = new List<Picture>();
                        SGrapics.Season = "";
                    }
                }

                if (SRange.HasFlag(Range.ImgSeasonWide))
                {
                    if (GCount.seasonwide > 0)
                    {
                        SGrapics.SeasonWides = await Pictures.GetPictures(SeriesID, Graphics.SeasonWide);

                        Picture seasonwide = SGrapics.SeasonWides.OrderByDescending(item => item.RatingsInfos.Average)
                                                        .ThenByDescending(item => item.RatingsInfos.Count)
                                                        .ThenByDescending(item => item.LanguageID)
                                                        .FirstOrDefault();
                        SGrapics.SeasonWide = seasonwide?.FileName;
                    }
                    else
                    {
                        SGrapics.SeasonWides = new List<Picture>();
                        SGrapics.SeasonWide = "";
                    }
                }

                if (SRange.HasFlag(Range.ImgSeries))
                {
                    if (GCount.series > 0)
                    {
                        SGrapics.Series = await Pictures.GetPictures(SeriesID, Graphics.Series);

                        Picture serie = SGrapics.Series.OrderByDescending(item => item.RatingsInfos.Average)
                                                        .ThenByDescending(item => item.RatingsInfos.Count)
                                                        .ThenByDescending(item => item.LanguageID)
                                                        .FirstOrDefault();
                        SGrapics.Serie = serie?.FileName;
                    }
                    else
                    {
                        SGrapics.Series = new List<Picture>();
                        SGrapics.Serie = "";
                    }
                }

                Serie.Graphics = SGrapics;
            }
            return Serie;
        }

        /// <summary>
        /// Gets a Series only with specified properties.
        /// </summary>
        /// <param name="SeriesID">Series ID to fetch.</param>
        /// <returns></returns>
        public SeriesFilter GetFilteredSeries(uint SeriesID)
        {
            return new SeriesFilter(ApiConfig, SeriesID);
        }
    }
}
