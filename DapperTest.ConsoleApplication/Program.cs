using DapperTest.Common.Interface.ApplicationService;
using DapperTest.Common.Models.People;
using Unity;

namespace DapperTest.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ContainerRegister.InitContainer();
            var container = ContainerRegister.GetContainer();
            var personApplicationService = container.Resolve<IPersonApplicationService>();

            personApplicationService.Insert(new Person("test name2", "test remark2"));
        }
    }
}