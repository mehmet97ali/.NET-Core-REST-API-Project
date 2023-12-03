using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProject.Application.Plannings.GetCustomerPlannings
{
    public class TeamPlanningDto
    {
        public string TeamName { get; set; }
        public List<PlanningDto> TeamPlannings { get; set; }
    }
}
