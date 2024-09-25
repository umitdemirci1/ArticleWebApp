using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace BlogProject.MVC.Helpers
{
    public class ApiClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public ApiClientHelper(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        private async Task<HttpRequestMessage> CreateRequestAsync(HttpMethod method, string requestUri, HttpContent content = null)
        {
            var request = new HttpRequestMessage(method, requestUri);
            var token = _httpContextAccessor.HttpContext?.Session.GetString("UserToken");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            if (content != null)
            {
                request.Content = content;
            }

            return request;
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");
            var request = await CreateRequestAsync(HttpMethod.Get, $"{baseUrl}/{requestUri}");

            var client = _httpClientFactory.CreateClient();
            var cts = new CancellationTokenSource(TimeSpan.FromMinutes(15));
            var response = await client.SendAsync(request, cts.Token);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PostAsync<T>(string requestUri, HttpContent content)
        {
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");
            var request = await CreateRequestAsync(HttpMethod.Post, $"{baseUrl}/{requestUri}", content);

            var client = _httpClientFactory.CreateClient();
            var cts = new CancellationTokenSource(TimeSpan.FromMinutes(15));
            var response = await client.SendAsync(request, cts.Token);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PutAsync<T>(string requestUri, HttpContent content)
        {
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");
            var request = await CreateRequestAsync(HttpMethod.Put, $"{baseUrl}/{requestUri}", content);

            var client = _httpClientFactory.CreateClient();
            var cts = new CancellationTokenSource(TimeSpan.FromMinutes(15));
            var response = await client.SendAsync(request, cts.Token);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PatchAsync<T>(string requestUri, HttpContent content)
        {
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");
            var request = await CreateRequestAsync(new HttpMethod("PATCH"), $"{baseUrl}/{requestUri}", content);

            var client = _httpClientFactory.CreateClient();
            var cts = new CancellationTokenSource(TimeSpan.FromMinutes(15));
            var response = await client.SendAsync(request, cts.Token);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task DeleteAsync(string requestUri)
        {
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");
            var request = await CreateRequestAsync(HttpMethod.Delete, $"{baseUrl}/{requestUri}");

            var client = _httpClientFactory.CreateClient();
            var cts = new CancellationTokenSource(TimeSpan.FromMinutes(15));
            var response = await client.SendAsync(request, cts.Token);
            response.EnsureSuccessStatusCode();
        }
    }
}
