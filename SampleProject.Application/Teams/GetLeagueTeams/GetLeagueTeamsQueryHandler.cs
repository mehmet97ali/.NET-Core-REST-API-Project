using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper;
using MediatR;

using SampleProject.Application.Configuration.Data;
using SampleProject.Application.Configuration.Queries;

using SampleProject.Application.Plannings.GetCustomerPlannings;

namespace SampleProject.Application.Teams.GetLeagueTeams
{
    internal sealed class GetLeagueTeamsQueryHandler : IQueryHandler<GetLeagueTeamsQuery, ResultLeagueTeamsDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        internal GetLeagueTeamsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ResultLeagueTeamsDto> Handle(GetLeagueTeamsQuery request, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "[CountryTeam].[Id], " +
                               "[CountryTeam].[CountryId], " +
                               "[CountryTeam].[Name] " +
                               "FROM teams.v_CountryTeams AS [CountryTeam] ";

            var sqlResult = await connection.QueryAsync<LeagueTeamsDto>(sql, new { request.NumberofGroups });
            var grouped = sqlResult.GroupBy(g => g.CountryId);
            var leagueTeams = new List<TeamPlanningDto>();

            const string teamNameSql = "SELECT " +
                   "[TeamName].[Name] " +
                   "FROM teams.TeamNames AS [TeamName] ";

            var teamNameSqlResult = await connection.QueryAsync<string>(teamNameSql);
            int numberOfGroups = request.NumberofGroups;

            foreach ( var teamName in teamNameSqlResult)
            {
                var leagueTeam = new TeamPlanningDto();
                var leagueTeamPlannings = new List<PlanningDto>();
                leagueTeam.TeamName = teamName;
                var teamCount = 0;
                foreach (var group in grouped)
                {
                    teamCount++;
                    var leagueTeamPlan = new PlanningDto() { Name = group.FirstOrDefault().Name};
                    leagueTeamPlannings.Add(leagueTeamPlan);
                    if (teamCount >= numberOfGroups) break;
                }
                leagueTeam.TeamPlannings = leagueTeamPlannings;
                leagueTeams.Add(leagueTeam);
            }

            return new ResultLeagueTeamsDto() { TeamPlannings = leagueTeams };
        }
    }
}