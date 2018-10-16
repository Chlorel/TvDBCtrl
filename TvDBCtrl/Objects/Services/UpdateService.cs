using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using TvDBCtrl.Client;
using TvDBCtrl.Objects.Converters;
using TvDBCtrl.Objects.Models;
using TvDBCtrl.Objects.Responses;

namespace TvDBCtrl.Objects.Services
{
    /// <summary>
    /// Methods relating to Updates to information from TVDB.
    /// </summary>
    public class UpdateService : BaseService
    {
        internal UpdateService(Configuration Config) : base(Config)
        {
        }

        /// <summary>
        /// Gets Series updates from the Specified FromTime. If ToTime isn't specified, it collects 7 days worth of Updates.
        /// </summary>
        /// <param name="FromTime">Updated From</param>
        /// <param name="ToTime">Updated to</param>
        /// <returns>Updated Series.</returns>
        public async Task<List<Update>> GetSeriesUpdates(DateTime FromTime, DateTime? ToTime = null)
        {
            if (!ToTime.HasValue)
            {
                ToTime                      = FromTime.AddDays(7);
            }
            HttpResponseMessage response    = await GetAsync(ApiConfig.BaseUrl + $"/updated/query?fromTime={FromTime.ToEpoch()}&toTime{ToTime.Value.ToEpoch()}");
            string              jsonData    = await response.Content.ReadAsStringAsync();
            List<Update>        result      = JsonConvert.DeserializeObject<Updates_R>(jsonData).Data;
            JsonErrors          errors      = JsonConvert.DeserializeObject<_jsonerrors>(jsonData).Errors;

            return result;
        }

        /// <summary>
        /// Gets the last time the Series was updated.
        /// </summary>
        /// <param name="SeriesID">Series ID to query.</param>
        /// <returns>Time last updated.</returns>
        public async Task<DateTimeOffset?> GetLastUpdatedForSeries(uint SeriesID)
        {
            HttpResponseMessage response    = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/filter?keys=lastUpdated");
            return response.Content.Headers.LastModified;
        }
    }
}
