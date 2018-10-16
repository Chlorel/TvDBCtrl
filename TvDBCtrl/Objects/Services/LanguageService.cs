using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TvDBCtrl.Client;
using TvDBCtrl.Objects.Models;
using TvDBCtrl.Objects.Responses;
namespace TvDBCtrl.Objects.Services
{
    /// <summary>
    /// Methods relating to Language Information.
    /// </summary>
    public class LanguageService : BaseService
    {
        internal LanguageService(Configuration Config) : base(Config)
        {
        }

        /// <summary>
        /// Fetches TvDB supported languages.
        /// </summary>
        /// <returns>List of languages</returns>
        public async Task<List<Language>> GetLanguage()
        {
            HttpResponseMessage response    = await GetAsync(ApiConfig.BaseUrl + $"/languages");
            string              jsonData    = await response.Content.ReadAsStringAsync();
            List<Language>      result      = JsonConvert.DeserializeObject<_language>(jsonData).Data;
            JsonErrors          errors      = JsonConvert.DeserializeObject<_jsonerrors>(jsonData).Errors;

            return result;
        }
    }
}
