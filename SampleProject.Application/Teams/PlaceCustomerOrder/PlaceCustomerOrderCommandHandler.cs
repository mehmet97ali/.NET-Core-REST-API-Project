using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SampleProject.Application.Configuration.Commands;
using SampleProject.Application.Configuration.Data;
using SampleProject.Domain.Customers;
using SampleProject.Domain.Customers.Orders;
using SampleProject.Domain.Plannings;

namespace SampleProject.Application.Orders.PlaceCustomerOrder
{
    public class PlaceCustomerOrderCommandHandler : ICommandHandler<PlaceCustomerOrderCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;

        private readonly IPlanningRepository _planningRepository;

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        
        public PlaceCustomerOrderCommandHandler(
            ICustomerRepository customerRepository,
            ISqlConnectionFactory sqlConnectionFactory,
            IPlanningRepository planningRepository)
        {
            _customerRepository = customerRepository;
            _sqlConnectionFactory = sqlConnectionFactory;
            _planningRepository = planningRepository;
        }

        public async Task<Guid> Handle(PlaceCustomerOrderCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(new PersonId(command.CustomerId));

            var orderPlanningsData = command
                .Plannings
                .Select(x => new OrderPlanningData(new PlanningId(new Guid()), 0))
                .ToList();          
            
            var orderId = customer.PlaceOrder(orderPlanningsData, command.Description, command.OrderDate);

            //CREATE PLANNING
            for (int i = 0; i < command.Plannings.Count; i++)
            {
                var newPlanning = command.Plannings[i];

                var planning = Planning.CreateRegistered("", "");

                await this._planningRepository.AddAsync(planning);
            }

            return orderId.Value;
        }
    }
}