using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Avola.Client
{
    internal class AvolaApiAuthenticationMessageHandler : DelegatingHandler
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _authenticationUrl;
        private readonly string _authenticationScope;
        private readonly bool _validateAllServerCertificates;
        private readonly X509Certificate2 _certificate;

        private readonly bool _useCertificate = false;

        public AvolaApiAuthenticationMessageHandler(string clientId, string clientSecret, string authenticationUrl, string authenticationScope, bool validateAllServerCertificates)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _authenticationUrl = authenticationUrl;
            _authenticationScope = authenticationScope;
            _validateAllServerCertificates = validateAllServerCertificates;
        }

        public AvolaApiAuthenticationMessageHandler(string clientId, X509Certificate2 certificate)
        {
            _clientId = clientId;
            _certificate = certificate;
            _useCertificate = true;
        }

        private TokenResponse _token = null;
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_token == null)
            {
                _token = _useCertificate ? await GetTokenWithCertificateAsync() : await GetTokenWithSecretAsync();
            }

            request.Headers.Authorization = new AuthenticationHeaderValue(_token.TokenType, _token.AccessToken);
            var response = await base.SendAsync(request, cancellationToken);

            // if we get a 401, get token again and retry
            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _token = _useCertificate ? await GetTokenWithCertificateAsync() : await GetTokenWithSecretAsync();
                    request.Headers.Authorization = new AuthenticationHeaderValue(_token.TokenType, _token.AccessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            return response;
        }

        private async Task<TokenResponse> GetTokenWithSecretAsync()
        {
            var client = new TokenClient(_authenticationUrl, _clientId, _clientSecret);
            return await client.RequestClientCredentialsAsync(_authenticationScope);
        }

        private async Task<TokenResponse> GetTokenWithCertificateAsync()
        {
            var handler = new WebRequestHandler();
            if (_validateAllServerCertificates) handler.ServerCertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;
            handler.ClientCertificates.Add(_certificate);

            var client = new TokenClient(
                _authenticationUrl,
                _clientId,
                handler);


            return await client.RequestClientCredentialsAsync(_authenticationScope);
        }

    }
}
