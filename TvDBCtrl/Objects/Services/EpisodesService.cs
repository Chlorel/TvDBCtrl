using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using TvDBCtrl.Client;
using TvDBCtrl.Objects.Models;
using TvDBCtrl.Objects.Responses;

namespace TvDBCtrl.Objects.Services
{
    /// <summary>
    /// Methods relating to fetching Episode information for a Series.
    /// </summary>
    public class EpisodesService : BaseService
    {
        private Language UserLanguage;
        internal EpisodesService(Configuration Config) : base(Config)
        {
        }

        /// <summary>
        /// Episodes Summary for a Series.
        /// </summary>
        /// <param name="SeriesID">Series to Query Episodes from</param>
        /// <returns>Episodes summary for Series</returns>
        public async Task<EpisodeSummary> EpisodesSummary       ( uint SeriesID )
        {
            HttpResponseMessage     response    = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/episodes/summary");
            string                  jsonData    = await response.Content.ReadAsStringAsync();
            EpisodeSummary          result      = JsonConvert.DeserializeObject<_episodesum>(jsonData).Data;
            JsonErrors              errors      = JsonConvert.DeserializeObject<_jsonerrors>(jsonData).Errors;

            return result;
        }

        /// <summary>
        /// Fetches all Episodes from every season for a Series.
        /// </summary>
        /// <param name="SeriesID">Series to Fetch Episodes from</param>
        /// <returns>List of Episodes</returns>
        public async Task<List<Episode>> GetAllEpisodes         ( uint SeriesID )
        {
            int             page        = 1;
            List<Episode>   Episodes    = new List<Episode>();
            List<Episode>   EpisodesUL  = new List<Episode>();
            List<Episode>   EpisodesDL  = new List<Episode>();
            UserLanguage                = ApiConfig.UserLanguage;
            while (true)
            {
                HttpResponseMessage responseUL  = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/episodes?page={page}");
                string              jsonDataUL  = await responseUL.Content.ReadAsStringAsync();
                _episodes           resultUL    = JsonConvert.DeserializeObject<_episodes>(jsonDataUL);
                JsonErrors          errorsUL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataUL).Errors;
                EpisodesUL.AddRange(resultUL.Data);

                if (!InDefaultLanguage())
                {
                    ApiConfig.UserLanguage          = ApiConfig.DefaultLanguage;
                    HttpResponseMessage responseDL  = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/episodes?page={page}");
                    string              jsonDataDL  = await responseDL.Content.ReadAsStringAsync();
                    _episodes           resultDL    = JsonConvert.DeserializeObject<_episodes>(jsonDataDL);
                    JsonErrors          errorsDL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataDL).Errors;
                    ApiConfig.UserLanguage          = UserLanguage;
                    EpisodesDL.AddRange(resultDL.Data);
                }

                if (resultUL.Links.Next == null)
                {
                    break;
                }
                page++;
            }
            Episodes = MergeEpisodeInfos
                (
                EpisodesUL.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList(), 
                EpisodesDL.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList()
                );

            return Episodes;
        }

        /// <summary>
        /// Fetches all Episodes a needed season for a Series.
        /// </summary>
        /// <param name="SeriesID">Series to Fetch Episodes from</param>
        /// <param name="airedSeason">Needed Season</param>
        /// <returns>List of Episodes</returns>
        public async Task<List<Episode>> GetEpisodesForSeason   ( uint SeriesID, uint airedSeason )
        {
            int page = 1;
            List<Episode>           Episodes    = new List<Episode>();
            List<Episode>           EpisodesUL  = new List<Episode>();
            List<Episode>           EpisodesDL  = new List<Episode>();
            UserLanguage                        = ApiConfig.UserLanguage;
            while (true)
            {
                HttpResponseMessage responseUL  = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/episodes/query?airedSeason={airedSeason}&page={page}");
                string              jsonDataUL  = await responseUL.Content.ReadAsStringAsync();
                _episodes           resultUL    = JsonConvert.DeserializeObject<_episodes>(jsonDataUL);
                JsonErrors          errorsUL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataUL).Errors;
                EpisodesUL.AddRange(resultUL.Data);

                if (!InDefaultLanguage())
                {
                    ApiConfig.UserLanguage              = ApiConfig.DefaultLanguage;
                    HttpResponseMessage     responseDL  = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/episodes/query?airedSeason={airedSeason}&page={page}");
                    string                  jsonDataDL  = await responseDL.Content.ReadAsStringAsync();
                    _episodes               resultDL    = JsonConvert.DeserializeObject<_episodes>(jsonDataDL);
                    JsonErrors              errorsDL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataDL).Errors;
                    ApiConfig.UserLanguage              = UserLanguage;
                    EpisodesDL.AddRange(resultDL.Data);
                }


                if (resultUL.Links.Next == null) break;
                page++;
            }

            Episodes = MergeEpisodeInfos
                (
                EpisodesUL.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList(),
                EpisodesDL.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList()
                );

            return Episodes;
        }

        /// <summary>
        /// Fetches the specific Episodes from a specific season.
        /// </summary>
        /// <param name="SeriesID">Series to Fetch Episodes from</param>
        /// <param name="airedSeason">Season for the needed Episode</param>
        /// <param name="airedEpisode">Episode to fetch</param>
        /// <returns>List of Episodes</returns>
        public async Task<List<Episode>> GetEpisode             ( uint SeriesID, uint airedSeason, uint airedEpisode )
        {
            List<Episode>       Episodes    = new List<Episode>();
            List<Episode>       EpisodesUL  = new List<Episode>();
            List<Episode>       EpisodesDL  = new List<Episode>();
            UserLanguage                    = ApiConfig.UserLanguage;

            HttpResponseMessage responseUL  = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/episodes/query?airedSeason={airedSeason}&airedEpisode={airedEpisode}");
            string              jsonDataUL  = await responseUL.Content.ReadAsStringAsync();
            _episodes           resultUL    = JsonConvert.DeserializeObject<_episodes>(jsonDataUL);
            JsonErrors          errorsUL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataUL).Errors;
            EpisodesUL.AddRange(resultUL.Data);

            if (!InDefaultLanguage())
            {
                ApiConfig.UserLanguage          = ApiConfig.DefaultLanguage;
                HttpResponseMessage responseDL  = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/episodes/query?airedSeason={airedSeason}&airedEpisode={airedEpisode}");
                string              jsonDataDL  = await responseDL.Content.ReadAsStringAsync();
                _episodes           resultDL    = JsonConvert.DeserializeObject<_episodes>(jsonDataDL);
                JsonErrors          errorsDL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataDL).Errors;
                ApiConfig.UserLanguage          = UserLanguage;
                EpisodesDL.AddRange(resultDL.Data);
            }

            Episodes = MergeEpisodeInfos
                (
                EpisodesUL.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList(),
                EpisodesDL.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList()
                );

            return Episodes;
        }

        /// <summary>
        /// Gets a singular Episode from it's Episode ID.
        /// </summary>
        /// <param name="EpisodeID">Episode ID</param>
        /// <returns>List of Episodes</returns>
        public async Task<List<Episode>> GetEpisode             ( uint EpisodeID )
        {
            List<Episode>   Episodes        = new List<Episode>();
            List<Episode>   EpisodesUL      = new List<Episode>();
            List<Episode>   EpisodesDL      = new List<Episode>();
            UserLanguage                    = ApiConfig.UserLanguage;

            HttpResponseMessage responseUL  = await GetAsync(ApiConfig.BaseUrl + $"/episodes/{EpisodeID}");
            string              jsonDataUL  = await responseUL.Content.ReadAsStringAsync();
            _episodes           resultUL    = JsonConvert.DeserializeObject<_episodes>(jsonDataUL);
            JsonErrors          errorsUL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataUL).Errors;
            EpisodesUL.AddRange(resultUL.Data);

            if (!InDefaultLanguage())
            {
                ApiConfig.UserLanguage          = ApiConfig.DefaultLanguage;
                HttpResponseMessage responseDL  = await GetAsync(ApiConfig.BaseUrl + $"/episodes/{EpisodeID}");
                string              jsonDataDL  = await responseDL.Content.ReadAsStringAsync();
                _episodes           resultDL    = JsonConvert.DeserializeObject<_episodes>(jsonDataDL);
                JsonErrors          errorsDL    = JsonConvert.DeserializeObject<_jsonerrors>(jsonDataDL).Errors;
                ApiConfig.UserLanguage          = UserLanguage;
                EpisodesDL.AddRange(resultDL.Data);
            }

            Episodes = MergeEpisodeInfos
                (
                EpisodesUL.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList(),
                EpisodesDL.OrderBy(item => item.SeasonNumber).ThenBy(item => item.EpisodeNumber).ToList()
                );

            return Episodes;
        }
    }
}
