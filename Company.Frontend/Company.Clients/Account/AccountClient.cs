using Company.Application.DTO;
using Company.Clients.Base;
using Company.Clients.Interfaces;
using System.Net.Http.Json;

namespace Company.Clients.Account
{
    public class AccountClient : BaseClient, IAccountClient
    {
        public AccountClient(HttpClient httpClient) 
            : base(httpClient, "api/account")
        {
        }

        public async Task<ResponseLogin> Login(RequestLogin request)
        {
            var result = await PostAsync("login", request);
            return await result!.EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<ResponseLogin>();
        }
    }
}
