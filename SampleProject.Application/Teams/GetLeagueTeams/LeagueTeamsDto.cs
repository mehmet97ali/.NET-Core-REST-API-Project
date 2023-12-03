using SampleProject.Application.Plannings.GetCustomerPlannings;
using System;
using System.Collections.Generic;

namespace SampleProject.Application.Teams.GetLeagueTeams
{
    public class LeagueTeamsDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public bool IsRemoved { get; set; }
        public string Name { get; set; }
        public List<PlanningDto> Plannings { get; set; }
    }
}