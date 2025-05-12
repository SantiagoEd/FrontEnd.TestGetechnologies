using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.TestGetechnologies.Service.Persona
{
    public class RestApiConsumer : IRestApiConsumer
    {
        public readonly RestClient _restClient;

        public RestApiConsumer(string Url)
        {
            if (string.IsNullOrEmpty(Url)) { throw new ArgumentNullException(nameof(Url)); }
            _restClient = new RestClient(Url);
        }
        public IAuthenticator authenticator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task<TResponse> Consume<TResponse>(string action, object request, Method method = Method.Get) where TResponse : new()
        {
            var restRequest = new RestRequest(action, method);
            if (request != null) { restRequest.AddJsonBody(request); }
            restRequest.Timeout = TimeSpan.FromSeconds(60000);

            var restResponse = _restClient.Execute<TResponse>(restRequest);//await _restClient.ExecuteAsync<TResponse>(restRequest);

            if (restResponse.ErrorException != null) { throw new Exception(restResponse.ErrorException.Message); }

            return restResponse!.Data!;
        }
    }
}
