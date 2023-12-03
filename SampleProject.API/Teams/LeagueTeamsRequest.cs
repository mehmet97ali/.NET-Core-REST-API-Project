using System;
using System.Collections.Generic;

using SampleProject.Application.Plannings.GetCustomerPlannings;

namespace SampleProject.API.Teams
{
    public class LeagueTeamsRequest
    {
        public List<PlanningDto> Plannings { get; set; }

        public string Description { get; set; }

        public DateTime OrderDate { get; set; }
    }
}