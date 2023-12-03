using System;
using System.Runtime.InteropServices.ComTypes;

namespace SampleProject.Application.Plannings.GetCustomerPlannings
{
    public class PlanningDto
    {
        public string Name { get; set; }

        public PlanningDto()
        {
            
        }

        public PlanningDto(string name)
        {
            this.Name = name;
        }
    }
}