using SampleProject.Domain.SeedWork;

namespace SampleProject.Domain.Customers
{
    public class CustomerRegisteredEvent : DomainEventBase
    {
        public PersonId personId { get; }

        public CustomerRegisteredEvent(PersonId personId)
        {
            this.personId = personId;
        }
    }
}