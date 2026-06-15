using ReactIntegrationsDemo.Models;
using System.Text.Json;

namespace ReactIntegrationDemo.Api.Clients
{
    public class ErpApiClient
    {
        private readonly HttpClient _httpClient;

        public ErpApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExternalCustomer>> GetCustomersAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var users = JsonSerializer.Deserialize<List<JsonPlaceholderUser>>(json);

            return users.Select(user => new ExternalCustomer
            {
                customer_id = user.id,
                full_name = user.name,
                email_address = user.email
            }).ToList();
        }
    }

    public class JsonPlaceholderUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}