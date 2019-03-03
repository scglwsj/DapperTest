using System.Collections.Generic;
using DapperTest.Common.Models.Pages;
using DapperTest.Common.Models.People;

namespace DapperTest.Common.Interface.Repository
{
    public interface IPersonRepository
    {
        void Insert(PersonDo person);
        void InsertBulk(IReadOnlyList<PersonDo> people);
        PersonDo FindById(int id);
        IList<PersonDo> FindByIds(IReadOnlyList<int> ids);
        Page<PersonDo> GetPage(int pageSize, int pageIndex);
        void Update(PersonDo personDo);
    }
}