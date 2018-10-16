using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TvDBCtrl.Objects.Requests;
using TvDBCtrl.Objects.Services;
using TvDBCtrl.Objects.Models;

namespace TvDBCtrl.Client
{
    /// <summary>
    /// The TVDB V2 API Client.
    /// </summary>
    public class TvDBClient
    {
        /// <summary>
        /// Dictionnaire des Languages existants 
        /// TKey   : string   pour l'abreviation du language
        /// TValue : Language pour ma structure language completée
        /// </summary>
        private Dictionary<string, Language>    ILanguages;

        /// <summary>
        /// The Configuration information for the API.
        /// </summary>
        private Configuration                   ApiConfig;

        /// <summary>
        /// The Primary Url for the TVDB API.
        /// </summary>
        public const string                     DefaultUrl          = "https://api.thetvdb.com";

        /// <summary>
        /// The Primary Url for TVDB Images.
        /// </summary>
        public readonly string                  BannersUrl          = "http://www.thetvdb.com/banners/";

        /// <summary>
        /// Methods relating to Authentication of the Client.
        /// </summary>
        public readonly AuthService             Authentication;

        /// <summary>
        /// Methods retrieving all accepted Languages.
        /// </summary>
        public readonly LanguageService         Langues;

        /// <summary>
        /// Methods relating to fetching Series Information.
        /// </summary>
        public readonly SeriesService           Series;

        /// <summary>
        /// Methods relating to Actor Information.
        /// </summary>
        public readonly ActeurService           Acteurs;

        /// <summary>
        /// Methods relating to fetching Episode information for a Series.
        /// </summary>
        public readonly EpisodesService         Episodes;

        /// <summary>
        /// Methods relating to Graphic information to a given Serie
        /// </summary>
        public readonly PicturesService         Pictures;

        /// <summary>
        /// Methods relating to Updates to information from TVDB.
        /// </summary>
        public readonly UpdateService           Updates;

        /// <summary>
        /// List of allowed languages
        /// </summary>
        private List<Language>                  LanguagesList;
        private Language                        _language;
        private string                          _languageName;
        /// <summary>
        /// Creates a new instance with the provided api configuration
        /// </summary>
        /// <param name="Config">The API configuration</param>
        private TvDBClient(Configuration Config)
        {
            if (Config == null)
                throw new ArgumentNullException(nameof(Config));


            // Init Services
            Authentication  = new AuthService(Config);
            Langues         = new LanguageService(Config);
            Series          = new SeriesService(Config);
            Acteurs         = new ActeurService(Config);
            Episodes        = new EpisodesService(Config);
            Pictures        = new PicturesService(Config);
            Updates         = new UpdateService(Config);

            this.ApiConfig  = Config;
        }

        /// <summary>
        /// Creates a new instance with the provided API key and a base api url
        /// </summary>
        /// <param name="Token">The Authenticated Token provided by TVDB, by entering API key, Login Details into Login Function</param>
        /// <param name="baseUrl">The API base url</param>
        public TvDBClient(string Token = null, string BaseUrl = DefaultUrl) : this(new Configuration(Token, BaseUrl))
        {
        }

        ~TvDBClient()
        {
        }

        /// <summary>
        /// Set the given APIKey and try to init 
        /// </summary>
        /// <param name="APIKey">The TvDB APIKey</param>
        /// <returns>true or false</returns>
        public async Task<bool> SetAPIKey ( string APIKey )
        {
            bool        bResult         = false;
            Credential  _credential     = new Credential(APIKey);
            JwtToken    Token           = await Authentication.GetJwtToken(_credential);
            if (!string.IsNullOrEmpty(Token.Token))
            {
                ApiConfig.SetToken(Token.Token);
                this.ILanguages = new Dictionary<string, Language>();
                LanguagesList   = await Langues.GetLanguage();
                foreach (Language Lng in LanguagesList)
                {
                    ILanguages.Add(Lng.abbreviation.ToUpper(), Lng);
                    if (Lng.abbreviation.ToLower() == "en")
                    {
                        ApiConfig.SetDefaultLanguage(Lng);
                    }
                    if (!string.IsNullOrEmpty(_languageName))
                    {
                        if (Lng.abbreviation.ToUpper() == _languageName.ToUpper())
                        {
                            ApiConfig.SetLanguage(Lng);
                            _language   = Lng;
                        }
                    }
                }
                bResult = true;
            }
            return bResult;
        }

        /// <summary>
        /// List Out the allowed Languages
        /// </summary>
        public List<string> Languages
        {
            get
            {
                List<string> _Languages = new List<string>();
                foreach (Language Lng in LanguagesList)
                {
                    _Languages.Add(Lng.abbreviation.ToUpper());
                }
                return _Languages;
            }
        }

        /// <summary>
        /// Choose the language.
        /// </summary>
        public string Language
        {
            get
            {
                return ApiConfig.UserLanguage.abbreviation.ToUpper();
            }
            set
            {
                _languageName   = value;
                if (ILanguages != null)
                {
                    if (ILanguages.ContainsKey(_languageName.ToUpper()))
                    {
                        _language   = ILanguages[_languageName.ToUpper()];
                        ApiConfig.SetLanguage(_language);
                    }
                }
            }
        }
    }
}
