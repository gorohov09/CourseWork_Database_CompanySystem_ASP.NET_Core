using System.Net.Http.Json;

namespace Company.Clients.Base
{
    public abstract class BaseClient
    {
        protected HttpClient HttpClient { get; }

        protected string Address { get; }

        public BaseClient(HttpClient httpClient, string address)
        {
            HttpClient = httpClient;
            Address = address;
        }

        protected async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default)
        {
            var address = $"{Address}/{url}";
            var response = await HttpClient.GetAsync(address, cancellationToken).ConfigureAwait(false);
            return await response
                .EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<T>()
                .ConfigureAwait(false);
        }

        protected async Task<HttpResponseMessage?> PostAsync<T>(string url, T value, CancellationToken cancel = default)
        {
            var address = $"{Address}/{url}";
            var response = await HttpClient.PostAsJsonAsync(address, value, cancel).ConfigureAwait(false);
            return response.EnsureSuccessStatusCode();
        }

        protected async Task<HttpResponseMessage?> PutAsync<T>(string url, T value, CancellationToken cancel = default)
        {
            var address = $"{Address}/{url}";
            var response = await HttpClient.PutAsJsonAsync(address, value, cancel).ConfigureAwait(false);
            return response.EnsureSuccessStatusCode();
        }
    }
}
