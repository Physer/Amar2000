using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using eFocus.Amar2000.Datasources.Netatmo.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace eFocus.Amar2000.Datasources.Netatmo.Session
{
    public class NetatmoSessionProvider
    {
        private NetatmoSession _currentSession;

        public virtual async Task<NetatmoSession> GetSession()
        {
            if (_currentSession == null ||string.IsNullOrWhiteSpace(_currentSession.AccessToken) || string.IsNullOrWhiteSpace(_currentSession.RefreshToken))
                return _currentSession = await Authenticate();

            var expireDate = _currentSession.SessionStartedUtc.AddSeconds(_currentSession.ExpiresIn);

            if (DateTime.UtcNow >= expireDate)
                _currentSession = await Refresh(_currentSession.RefreshToken);

            return _currentSession;
        }

        protected virtual async Task<NetatmoSession> Authenticate()
        {
            var client = new RestClient("https://api.netatmo.com");

            var sessionStartedUtc = DateTime.UtcNow;

            var request = new RestRequest("oauth2/token", Method.POST);

            request.AddParameter("grant_type", "password");
            request.AddParameter("client_id", ConfigurationManager.AppSettings["Netatmo.ClientId"]);
            request.AddParameter("client_secret", ConfigurationManager.AppSettings["Netatmo.Secret"]);
            request.AddParameter("username", ConfigurationManager.AppSettings["Netatmo.Username"]);
            request.AddParameter("password", ConfigurationManager.AppSettings["Netatmo.Password"]);
            request.AddParameter("scope", "read_station");

            

            var response = await client.ExecuteTaskAsync(request);

            var session = JsonConvert.DeserializeObject<NetatmoSession>(response.Content);
            session.SessionStartedUtc = sessionStartedUtc;
            
            return session;
        }

        protected virtual async Task<NetatmoSession> Refresh(string refreshToken)
        {
            var client = new RestClient("https://api.netatmo.com");

            var sessionStartedUtc = DateTime.UtcNow;

            var request = new RestRequest("oauth2/token", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("refresh_token", refreshToken);
            request.AddParameter("client_id", ConfigurationManager.AppSettings["Netatmo_ClientId"]);
            request.AddParameter("client_secret", ConfigurationManager.AppSettings["Netatmo_Secret"]);

            var response = await client.ExecuteTaskAsync(request);

            var session = JsonConvert.DeserializeObject<NetatmoSession>(response.Content);
            session.SessionStartedUtc = sessionStartedUtc;

            return session;
        }
    }
}
