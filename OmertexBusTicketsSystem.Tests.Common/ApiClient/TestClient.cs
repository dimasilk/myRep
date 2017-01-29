using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.HttpClientWrapper.Interfaces;
using OmertexBusTicketsSystem.Tests.Common.ApiClient.Interfaces;
using OmertexBusTicketsSystem.Tests.Common.Infrastructure;

namespace OmertexBusTicketsSystem.Tests.Common.ApiClient
{
    public class TestClient : ITestClient
    {
        private readonly IRestClient _restClient;
        private OAuthToken _oAuthToken;

        public TestClient(IRestClient restClient)
        {
            _restClient = restClient;
        }
        public bool ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {

            var p = new Dictionary<string, string>
            {
                {"OldPassword", oldPassword},
                {"NewPassword", newPassword},
                {"ConfirmPassword", confirmPassword }
            };
            var content = new FormUrlEncodedContent(p);
            var reg = _restClient.MakeApiRequest(Constants.Constants.RequestChangePassword, HttpMethod.Post, content);

            return reg != null && reg.Success;
        }

        public bool Login(string userName, string password)
        {

            var p = new Dictionary<string, string>
            {
                {"grant_type", "password"},
                {"username", userName},
                {"password", password}
            };
            var content = new FormUrlEncodedContent(p);

            _oAuthToken = _restClient.MakeApiRequest<OAuthToken>(Constants.Constants.RequestToken, HttpMethod.Post, content);

            var authTokenRestClient = _restClient as ITokenAuth;
            if (authTokenRestClient != null)
                authTokenRestClient.AddToken(_oAuthToken.access_token);

            return _oAuthToken != null;
        }

        public bool Register(string userName, string email, string password, string passwordConfirm)
        {
            var p = new Dictionary<string, string>
            {
                {"name", userName},
                {"email", email},
                {"password", password},
                {"ConfirmPassword", passwordConfirm }
            };
            var content = new FormUrlEncodedContent(p);
            var reg = _restClient.MakeApiRequest(Constants.Constants.RequestRegister, HttpMethod.Post, content);

            return reg != null && reg.Success;
        }
    }
}
