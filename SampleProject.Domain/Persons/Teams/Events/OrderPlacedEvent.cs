using System;
using SampleProject.Domain.SeedWork;
using SampleProject.Domain.SharedKernel;

namespace SampleProject.Domain.Customers.Orders.Events
{
    public class OrderPlacedEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public PersonId PersonId { get; }

        public OrderPlacedEvent(
            OrderId orderId, 
            PersonId personId)
        {
            this.OrderId = orderId;
            this.PersonId = personId;
        }
    }
}