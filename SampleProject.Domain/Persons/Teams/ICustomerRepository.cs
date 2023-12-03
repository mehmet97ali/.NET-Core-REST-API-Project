using System;
using System.Threading.Tasks;

namespace SampleProject.Domain.Customers.Orders
{
    public interface ICustomerRepository
    {
        Task<Person> GetByIdAsync(PersonId id);

        Task AddAsync(Person person);
    }
}