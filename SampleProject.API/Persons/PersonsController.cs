using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using SampleProject.Application.Customers;
using SampleProject.Application.Customers.RegisterCustomer;

namespace SampleProject.API.Persons
{
    [Route("api/persons")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Register Person.
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(PersonDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterPerson([FromBody]RegisterPersonRequest request)
        {
           var customer = await _mediator.Send(new RegisterPersonCommand(request.Surname, request.Name));

           return Created(string.Empty, customer);
        }
    }
}
