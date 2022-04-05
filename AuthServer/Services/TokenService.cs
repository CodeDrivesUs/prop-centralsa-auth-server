using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Configuration;
using AuthServer.Models;

namespace AuthServer.Services
{
    public static class TokenService
    {
        public static async Task<string> GetBearerTokenAsync()
        {
            var clientId = AppSettings.ClientId;
            var clientSecret = AppSettings.ClientSecret;
            var url = new Uri(AppSettings.AuthorityUrl + "/connect/token");

            var client = new RestClient(url)
            {
                Authenticator = new HttpBasicAuthenticator(clientId, clientSecret)
            };

            var request = new RestRequest();
            request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);
            request.AddParameter("response_type", "application/json", ParameterType.GetOrPost);
            var response = await client.ExecuteAsync(request);
            if (string.IsNullOrEmpty(response.Content))
            {
                throw new Exception("Error retrieving Token for api");
            }
            var result = JsonConvert.DeserializeObject<SingInResponse>(response.Content);
            return result.access_token;
        }


    }
}
