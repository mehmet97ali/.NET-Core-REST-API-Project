using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using SampleProject.Application.Teams.GetLeagueTeams;
using SampleProject.Application.Orders.GetCustomerOrders;
using SampleProject.Application.Orders.RemoveCustomerOrder;
using SampleProject.Application.Orders.UpdateStatusOrder;
using SampleProject.Application.Plannings.GetCustomerPlannings;

namespace SampleProject.API.Teams
{
    [Route("api/Teams")]
    [ApiController]
    public class LeagueTeamsController : Controller
    {
        private readonly IMediator _mediator;

        public LeagueTeamsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Get League Teams.
        /// </summary>
        /// <param name="numberofGroups">Number of Groups.</param>
        [Route("{personId}/Teams/{numberofGroups}")]
        [HttpGet]
        [ProducesResponseType(typeof(LeagueTeamsDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLeagueTeams(
            [FromRoute]int numberofGroups)
        {
            var orderDetails = await _mediator.Send(new GetLeagueTeamsQuery(numberofGroups));

            return Ok(orderDetails);
        }

        /// <summary>
        /// Remove League Teams.
        /// </summary>
        /// <param name="personId">Person ID.</param>
        /// <param name="leagueTeamsId">league Teams ID.</param>
        [Route("{personId}/Teams/{leagueTeamsId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<OrderDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveLeagueTeams(
            [FromRoute]Guid personId,
            [FromRoute]Guid leagueTeamsId)
        {
            await _mediator.Send(new RemoveCustomerOrderCommand(personId, leagueTeamsId));

            return Ok();
        }

    }
}
