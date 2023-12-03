using MediatR;
using SampleProject.Application.Configuration.Commands;

namespace SampleProject.Application.Customers.RegisterCustomer
{
    public class RegisterPersonCommand : CommandBase<PersonDto>
    {
        public string Surname { get; }

        public string Name { get; }

        public RegisterPersonCommand(string surname, string name)
        {
            this.Surname = surname;
            this.Name = name;
        }      
    }
}