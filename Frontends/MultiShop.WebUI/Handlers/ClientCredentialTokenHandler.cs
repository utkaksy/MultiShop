
using MultiShop.WebUI.Services.Abstract;
using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _clientCredentialTokenService.GetToken();
            Console.WriteLine("TOKEN (handler): " + token);

            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",token);

            request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + token);

            var response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("RESPONSE STATUS: " + response.StatusCode);

            return response;
        }

    }
}
