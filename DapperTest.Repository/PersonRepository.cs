﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using DapperTest.Common.Interface.Repository;
using DapperTest.Common.Models.Pages;
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

        public Page<PersonDo> GetPage(int pageSize, int pageIndex)
        {
            const string querySql = @"SELECT * FROM (
                                    SELECT * ,ROW_NUMBER() OVER ( ORDER BY ID DESC) AS [PersonIndex] 
                                        FROM [People] 
                                    ) AS [PagePeople]
                                    WHERE [PersonIndex] > @PageSize * (@PageIndex - 1) 
                                    AND [PersonIndex] <= @PageSize * @PageIndex";
            const string countSql = "SELECT COUNT(Id) AS [Count] FROM [People] WHERE 1 = 1";
            using (var connection = DbConnection.GetDbConnection())
            {
                var items = connection.Query<PersonDo>(querySql, new
                {
                    PageSize = pageSize,
                    PageIndex = pageIndex
                }).ToList();
                var totalCount = connection.ExecuteScalar<int>(countSql);
                var pageCount = (int) Math.Ceiling((double) totalCount / pageSize);
                return new Page<PersonDo>(pageCount, totalCount, items);
            }
        }

        public void Update(PersonDo person)
        {
            const string sql =
                "UPDATE [People] SET [Name] = @Name, [Remark] = @Remark, [Status] = @Status WHERE Id = @Id";
            using (var connection = DbConnection.GetDbConnection())
            {
                connection.Execute(sql, person);
            }
        }

        public int Delete(Person person)
        {
            const string sql = "DELETE FROM [People] WHERE Id = @ID";
            using (var connection = DbConnection.GetDbConnection())

            {
                return connection.Execute(sql, person);
            }
        }

        public int Delete(IReadOnlyList<Person> people)
        {
            const string sql = "DELETE FROM [People] WHERE Id IN @Ids";
            using (var connection = DbConnection.GetDbConnection())

            {
                return connection.Execute(sql, people);
            }
        }
    }
}