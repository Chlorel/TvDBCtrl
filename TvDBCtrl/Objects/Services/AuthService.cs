using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TvDBCtrl.Client;
using TvDBCtrl.Objects.Models;
using TvDBCtrl.Objects.Requests;
using TvDBCtrl.Objects.Responses;


namespace TvDBCtrl.Objects.Services
{
    /// <summary>
    /// Methods relating to Authentication of the Client.
    /// </summary>
    public class AuthService : BaseService
    {
        internal AuthService(Configuration Config) : base(Config)
        {
        }

        public async Task<bool> CheckCredentials ( string APIKey )
        {
            bool                bResult     = false;
            Credential          _credential = new Credential(APIKey);
            HttpResponseMessage reponse     = await PostAsync(ApiConfig.BaseUrl + "/login", JsonConvert.SerializeObject(_credential));
            if (reponse.StatusCode == HttpStatusCode.OK)
            {
                bResult = true;
            }

            return bResult;
        }
        /// <summary>
        /// Gets the JWT Token from TVDB using the provided Credentials.
        /// </summary>
        /// <param name="Credentials">Credential Information</param>
        /// <returns>TVDB Token information</returns>
        public async Task<JwtToken> GetJwtToken(Credential Credentials)
        {
            HttpResponseMessage     reponse = await PostAsync(ApiConfig.BaseUrl + "/login", JsonConvert.SerializeObject(Credentials));
            string                  result  = await reponse.Content.ReadAsStringAsync();
            JwtToken                token   = JsonConvert.DeserializeObject<_token>(result).Data;
            return token;
        }

        /// <summary>
        /// Requests a refresh of the JWT Token.
        /// </summary>
        /// <returns>New TVDB Token information</returns>
        public async Task<JwtToken> RefreshToken()
        {
            HttpResponseMessage     reponse = await GetAsync(ApiConfig.BaseUrl + "/refresh_token");
            string                  result  = await reponse.Content.ReadAsStringAsync();
            JwtToken                token   = JsonConvert.DeserializeObject<_token>(result).Data;
            return token;
        }
    }
}
