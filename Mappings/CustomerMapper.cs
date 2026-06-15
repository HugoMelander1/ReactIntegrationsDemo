using ReactIntegrationsDemo.Models;

namespace ReactIntegrationDemo.Api.Mappings
{
    public static class CustomerMapper
    {
        public static InternalCustomer MapToInternal(ExternalCustomer customer)
        {
            return new InternalCustomer
            {
                Id = customer.customer_id,
                Name = customer.full_name,
                Email = customer.email_address
            };
        }
    }
}