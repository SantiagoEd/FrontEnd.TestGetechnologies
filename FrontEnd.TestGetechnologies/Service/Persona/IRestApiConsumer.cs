using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.TestGetechnologies.Service.Persona
{
    public interface IRestApiConsumer
    {
        IAuthenticator authenticator { set; get; }
        Task<TResponse> Consume<TResponse>(string action, object request, RestSharp.Method method) where TResponse : new();
    }
}
