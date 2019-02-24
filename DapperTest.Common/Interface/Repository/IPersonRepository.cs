using DapperTest.Common.Models.People;

namespace DapperTest.Common.Interface.Repository
{
    public interface IPersonRepository
    {
        void Insert(PersonDo person);
    }
}