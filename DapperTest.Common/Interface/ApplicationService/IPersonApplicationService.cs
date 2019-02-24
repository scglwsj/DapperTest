using System.Collections.Generic;
using DapperTest.Common.Models.People;

namespace DapperTest.Common.Interface.ApplicationService
{
    public interface IPersonApplicationService
    {
        void Insert(Person person);
        void InsertBulk(IReadOnlyList<Person> people);
        Person FindById(int id);
        IList<Person> FindByIds(IReadOnlyList<int> ids);
        void Delete(Person person);
    }
}