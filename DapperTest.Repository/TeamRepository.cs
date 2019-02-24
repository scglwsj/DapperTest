using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperTest.Common.Interface.Repository;
using DapperTest.Common.Models.People;
using DapperTest.Common.Models.Teams;

namespace DapperTest.Repository
{
    public class TeamRepository : ITeamRepository
    {
        public TeamDo FindById(int id)
        {
            const string sql = @"SELECT * FROM [Teams] t
                                 INNER JOIN[People] o
                                   ON o.Id = t.OwnerId
                                 INNER JOIN[TeamMembers] r
                                   ON r.TeamId = t.Id
                                 INNER JOIN[People] m
                                   ON m.Id = r.PersonId
                                 WHERE t.Id = @Id";

            using (var connection = DbConnection.GetDbConnection())
            {
                TeamDo result = null;

                return connection.Query<TeamDo, PersonDo, PersonDo, TeamDo>(sql, (team, owner, members) =>
                {
                    if (result == null)
                    {
                        result = team;
                        result.Owner = owner;
                        result.Members = new List<PersonDo>();
                    }

                    result.Members.Add(members);
                    return result;
                }, new {Id = id}).Distinct().SingleOrDefault();
            }
        }

        public TeamDo FindByOwnerId(int id)
        {
            const string sql = @"SELECT * FROM [People] WHERE [Id] = @Id And [Status] = 0;
                        SELECT * FROM [Teams] WHERE [OwnerId] = @Id";
            using (var connection = DbConnection.GetDbConnection())
            {
                using (var multi = connection.QueryMultiple(sql, new {Id = id}))
                {
                    var owner = multi.ReadSingle<PersonDo>();
                    var team = multi.ReadSingle<TeamDo>();
                    team.Owner = owner;
                    return team;
                }
            }
        }
    }
}