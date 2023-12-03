using System;
using MediatR;
using SampleProject.Application.Configuration.Queries;

namespace SampleProject.Application.Teams.GetLeagueTeams
{
    public class GetLeagueTeamsQuery : IQuery<ResultLeagueTeamsDto>
    {
        public int NumberofGroups { get; }

        public GetLeagueTeamsQuery(int numberofGroups)
        {
            this.NumberofGroups = numberofGroups;
        }
    }
}