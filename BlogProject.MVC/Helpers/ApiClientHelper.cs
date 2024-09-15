using System.Net.Http.Headers;

namespace BlogProject.MVC.Helpers
{
    public class ApiClientHelper
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        public ApiClientHelper(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        private void AddTokenToRequest()
        {
            var token = _httpContextAccessor.HttpContext.Request.Cookies["UserToken"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            AddTokenToRequest();
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");
      
            var response = await _httpClient.GetAsync($"{baseUrl}/{requestUri}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PostAsync<T>(string requestUri, HttpContent content)
        {
            AddTokenToRequest();
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");

            // İçeriğin doğru formatta olduğundan emin olun
            if (content.Headers.ContentType == null)
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            var response = await _httpClient.PostAsync($"{baseUrl}/{requestUri}", content);

            // Hata mesajını ve yanıtı inceleyin
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
            }

            return await response.Content.ReadFromJsonAsync<T>();
        }
        
         public async Task<T> PutAsync<T>(string requestUri, HttpContent content)
        {
            AddTokenToRequest();
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");

            var response = await _httpClient.PutAsync($"{baseUrl}/{requestUri}", content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PatchAsync<T>(string requestUri, HttpContent content)
        {
            AddTokenToRequest();
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{baseUrl}/{requestUri}")
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task DeleteAsync(string requestUri)
        {
            AddTokenToRequest();
            string baseUrl = _configuration.GetValue<string>("ApiSettings:BaseUrl");

            var response = await _httpClient.DeleteAsync($"{baseUrl}/{requestUri}");
            response.EnsureSuccessStatusCode();
        }
    }
}
