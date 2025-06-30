using IdentityModel;
using IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly ClientSettings _clientSettings;

        private const string TokenCacheKey = "multishoptoken";
        private const string DiscoveryCacheKey = "identity_discovery_document";

        public ClientCredentialTokenService(
            IOptions<ServiceApiSettings> serviceApiSettings,
            HttpClient httpClient,
            IOptions<ClientSettings> clientSettings,
            IMemoryCache memoryCache)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _memoryCache = memoryCache;
            _clientSettings = clientSettings.Value;
        }

        public async Task<string> GetToken()
        {
            if (_memoryCache.TryGetValue(TokenCacheKey, out string cachedToken))
            {
                return cachedToken;
            }

            var discovery = await GetDiscoveryDocumentAsync();

            var tokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discovery.TokenEndpoint,
                GrantType = OidcConstants.GrantTypes.ClientCredentials
            };

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(tokenRequest);

            if (tokenResponse.IsError)
            {
                throw new Exception("Token alınamadı: " + tokenResponse.ErrorDescription);
            }

            // Token'ı (süresi dolmadan) cache'e koy
            _memoryCache.Set(TokenCacheKey, tokenResponse.AccessToken,
                TimeSpan.FromSeconds(tokenResponse.ExpiresIn - 60));

            return tokenResponse.AccessToken;
        }

        private async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync()
        {
            if (_memoryCache.TryGetValue(DiscoveryCacheKey, out DiscoveryDocumentResponse cachedDiscovery))
            {
                return cachedDiscovery;
            }

            var discovery = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy { RequireHttps = false }
            });

            if (discovery.IsError)
            {
                throw new Exception("Discovery belgesi alınamadı: " + discovery.Error);
            }

            // 24 saatlik discovery cache süresi — istersen artırabilirsin
            _memoryCache.Set(DiscoveryCacheKey, discovery, TimeSpan.FromHours(24));

            return discovery;
        }
    }
}
