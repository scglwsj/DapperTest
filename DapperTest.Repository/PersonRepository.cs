using Dapper;
using DapperTest.Common.Interface.Repository;
using DapperTest.Common.Models.People;

namespace DapperTest.Repository
{
    public class PersonRepository: IPersonRepository
    {
        public void Insert(PersonDo person)
        {
            const string sql = "INSERT INTO [People] ([Name], [Remark], [Status]) VALUES (@Name, @Remark, @Status)";

            using (var connection = DbConnection.GetDbConnection())
            {
                connection.Execute(sql, person);
            }
        }
    }
}