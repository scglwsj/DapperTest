using DapperTest.Common.Models.People;

namespace DapperTest.Common.Interface.ApplicationService
{
    public interface IPersonApplicationService
    {
        void Insert(Person person);
    }
}