using Newtonsoft.Json;
using SampleProject.Application.Configuration.DomainEvents;
using SampleProject.Domain.Customers;

namespace SampleProject.Application.Customers.IntegrationHandlers
{
    public class CustomerRegisteredNotification : DomainNotificationBase<CustomerRegisteredEvent>
    {
        public PersonId CustomerId { get; }

        public CustomerRegisteredNotification(CustomerRegisteredEvent domainEvent) : base(domainEvent)
        {
            this.CustomerId = domainEvent.personId;
        }

        [JsonConstructor]
        public CustomerRegisteredNotification(PersonId customerId) : base(null)
        {
            this.CustomerId = customerId;
        }
    }
}