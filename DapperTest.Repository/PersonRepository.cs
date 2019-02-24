using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperTest.Common.Interface.Repository;
using DapperTest.Common.Models.People;

namespace DapperTest.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private const string InsertSql = @"INSERT INTO [People] VALUES (@Name, @Remark, @Status)";

        public void Insert(PersonDo person)
        {
            using (var connection = DbConnection.GetDbConnection())
            {
                connection.Execute(InsertSql, person);
            }
        }

        public void InsertBulk(IReadOnlyList<PersonDo> people)
        {
            using (var connection = DbConnection.GetDbConnection())
            {
                connection.Execute(InsertSql, people);
            }
        }

        public PersonDo FindById(int id)
        {
            const string sql = "SELECT * FROM [People] WHERE [Id] = @Id And [Status] = 0";
            using (var connection = DbConnection.GetDbConnection())
            {
                return connection.QuerySingle<PersonDo>(sql, new {Id = id});
            }
        }

        public IList<PersonDo> FindByIds(IReadOnlyList<int> ids)
        {
            const string sql = "SELECT * FROM [People] WHERE [Id] IN @IdS And [Status] = 0";
            using (var connection = DbConnection.GetDbConnection())
            {
                return connection.Query<PersonDo>(sql, new {Ids = ids}).ToList();
            }
        }
    }
}