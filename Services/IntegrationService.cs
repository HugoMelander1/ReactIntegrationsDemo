using ReactIntegrationDemo.Api.Clients;
using ReactIntegrationDemo.Api.Mappings;
using ReactIntegrationsDemo.Models;

namespace ReactIntegrationDemo.Api.Services
{
    public class IntegrationService
    {
        private readonly ErpApiClient _erpApiClient;

        public IntegrationService(ErpApiClient erpApiClient)
        {
            _erpApiClient = erpApiClient;
        }

        public async Task<List<InternalCustomer>> GetIntegratedCustomersAsync()
        {
            var externalCustomers = await _erpApiClient.GetCustomersAsync();

            return externalCustomers
                .Select(CustomerMapper.MapToInternal)
                .ToList();
        }
    }
}