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
            throw new System.NotImplementedException();
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