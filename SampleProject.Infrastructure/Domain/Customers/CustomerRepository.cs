using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Customers;
using SampleProject.Domain.Customers.Orders;
using SampleProject.Infrastructure.Database;
using SampleProject.Infrastructure.SeedWork;

namespace SampleProject.Infrastructure.Domain.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OrdersContext _context;

        public CustomerRepository(OrdersContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Person customer)
        {
            await this._context.Customers.AddAsync(customer);
        }

        public async Task<Person> GetByIdAsync(PersonId id)
        {
            return await this._context.Customers
                .IncludePaths(CustomerEntityTypeConfiguration.OrdersList, CustomerEntityTypeConfiguration.OrderPlannings)
                .SingleAsync(x => x.Id == id);
        }
    }
}