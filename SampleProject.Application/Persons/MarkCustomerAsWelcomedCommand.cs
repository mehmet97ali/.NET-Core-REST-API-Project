using System;
using MediatR;
using Newtonsoft.Json;
using SampleProject.Application.Configuration.Commands;
using SampleProject.Domain.Customers;

namespace SampleProject.Application.Customers
{
    public class MarkCustomerAsWelcomedCommand : InternalCommandBase<Unit>
    {
        [JsonConstructor]
        public MarkCustomerAsWelcomedCommand(Guid id, PersonId customerId) : base(id)
        {
            CustomerId = customerId;
        }

        public PersonId CustomerId { get; }
    }
}