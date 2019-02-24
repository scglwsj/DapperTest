using System.Collections.Generic;
using Dapper;
using DapperTest.Common.Interface.Repository;
using DapperTest.Common.Models.People;

namespace DapperTest.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private const string InsertSql = @"INSERT INTO [People] VALUES
            (@Name, @Remark, @Status)";

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
    }
}