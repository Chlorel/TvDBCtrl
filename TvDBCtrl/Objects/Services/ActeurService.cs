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
    /// Methods relating to Actor Information.
    /// </summary>
    public class ActeurService : BaseService
    {
        internal ActeurService(Configuration Config) : base(Config)
        {
        }

        /// <summary>
        /// Fetches Actors for a Series.
        /// </summary>
        /// <param name="SeriesID">Serie to Fetch Actors from</param>
        /// <returns>List of Actors for the given Serie</returns>
        public async Task<List<Acteur>> GetActors(uint SeriesID)
        {
            List<Acteur>            Acteurs     = new List<Acteur>();
            HttpResponseMessage     response    = await GetAsync(ApiConfig.BaseUrl + $"/series/{SeriesID}/actors");
            string                  jsonData    = await response.Content.ReadAsStringAsync();
            _acteurs                result      = JsonConvert.DeserializeObject<_acteurs>(jsonData);
            JsonErrors              errors      = JsonConvert.DeserializeObject<_jsonerrors>(jsonData).Errors;

            if (result.Data != null)
            {
                List<Acteur> _Acteurs = new List<Acteur>();
                _Acteurs.AddRange(result.Data);
                Acteurs = _Acteurs.OrderBy(item => item.SortOrder).ToList();
            }
            else
            {
                Acteurs = null;
            }

            return Acteurs;
        }
    }
}
