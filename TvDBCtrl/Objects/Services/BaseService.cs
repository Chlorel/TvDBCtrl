using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using TvDBCtrl.Client;
using TvDBCtrl.Objects.Exceptions;
using TvDBCtrl.Objects.Models;

namespace TvDBCtrl.Objects.Services
{
    /// <summary>
    /// Internal Http client for calls to the TVDB API.
    /// </summary>
    public abstract class BaseService
    {
        internal Configuration ApiConfig     { get; }

        internal BaseService(Configuration Config)
        {
            this.ApiConfig = Config ?? throw new ArgumentNullException(nameof(Config));
        }

        /// <summary>
        /// Creates Authentication Headers for the Client.
        /// </summary>
        private void CreateHeaders(HttpClient client, bool requiresAuth)
        {
            if (requiresAuth)
            {
                if (ApiConfig.UserLanguage != null)
                {
                    if (ApiConfig.UserLanguage.abbreviation != "en")
                    {
                        client.DefaultRequestHeaders.Add("Accept-Language", ApiConfig.UserLanguage.abbreviation.ToUpper() + " ");
                    }
                }
                client.DefaultRequestHeaders.Add("Authorization", ApiConfig.Token);
            }
        }

        protected async Task<HttpResponseMessage> GetAsync(string url, bool requiresAuth = true)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));

            try
            {
                Uri uri = new Uri(url);

                using (HttpClient client = new HttpClient())
                {
                    CreateHeaders(client, requiresAuth);
                    var response = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
                    if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NotFound)
                    {
                        throw new BadResponseException(response.StatusCode);
                    }
                    return response;
                }
            }
            catch (BadResponseException ex) { throw ex; }
            catch (Exception inner)
            {
                throw new NotAvailableException(inner: inner);
            }
        }

        protected async Task<HttpResponseMessage> PostAsync(string url, string data)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));

            try
            {
                Uri uri = new Uri(url);

                using (HttpClient client = new HttpClient())
                {
                    //CreateHeaders(client);
                    var response = await client.PostAsync(uri, new StringContent(data, new System.Text.UTF8Encoding(), "application/json"));
                    if (!response.IsSuccessStatusCode) throw new BadResponseException(response.StatusCode);

                    return response;
                }
            }
            catch (BadResponseException ex) { throw ex; }
            catch (Exception inner)
            {
                throw new NotAvailableException(inner: inner);
            }
        }

        protected bool InDefaultLanguage ()
        {
            bool bResult = false;

            if (ApiConfig.UserLanguage.abbreviation == ApiConfig.DefaultLanguage.abbreviation)
            {
                bResult = true;
            }
            return bResult;
        }

        protected List<SeriesSummary> MergeSummaryInfos ( List<SeriesSummary> User, List<SeriesSummary> Default )
        {
            if (!InDefaultLanguage())
            {
                int iCur;
                for (iCur = 0; iCur < User.Count; iCur++)
                {
                    if (string.IsNullOrEmpty(User[iCur].SeriesName))
                    {
                        if (User[iCur].TvDBID == Default[iCur].TvDBID)
                        {
                            if (!string.IsNullOrEmpty(Default[iCur].SeriesName))
                            {
                                User[iCur].SeriesName = Default[iCur].SeriesName;
                            }
                            else
                            {
                                User[iCur].SeriesName = $"Serie -  {Default[iCur].TvDBID}";
                            }
                            if (!string.IsNullOrEmpty(Default[iCur].Overview))
                            {
                                User[iCur].Overview = Default[iCur].Overview;
                            }
                        }
                    }
                }
            }
            return User;

        }

        protected List<Episode> MergeEpisodeInfos ( List<Episode> User, List<Episode> Default )
        {
            if (!InDefaultLanguage())
            {
                int iCur;
                for (iCur = 0; iCur < User.Count; iCur++)
                {
                    if (string.IsNullOrEmpty(User[iCur].EpisodeName))
                    {
                        if (User[iCur].EpisodeID == Default[iCur].EpisodeID)
                        {
                            if (!string.IsNullOrEmpty(Default[iCur].EpisodeName))
                            {
                                User[iCur].EpisodeName = Default[iCur].EpisodeName;
                            }
                            else
                            {
                                User[iCur].EpisodeName = $"Episode {Default[iCur].DVDEpisodeNumber}";
                            }
                            if (!string.IsNullOrEmpty(Default[iCur].Overview))
                            {
                                User[iCur].Overview = Default[iCur].Overview;
                            }
                        }
                    }
                }
            }
            return User;
        }
    }
}


