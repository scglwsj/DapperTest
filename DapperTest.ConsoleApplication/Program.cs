using DapperTest.ApplicationService;
using DapperTest.Common.Interface.ApplicationService;
using DapperTest.Common.Interface.Repository;
using DapperTest.Common.Models.People;
using DapperTest.Repository;
using Unity;

namespace DapperTest.ConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            //            ContainerRegister.InitContainer();
            container.RegisterType<IPersonApplicationService, PersonApplicationService>();
            container.RegisterType<IPersonRepository, PersonRepository>();

            var personApplicationService = container.Resolve<IPersonApplicationService>();
            personApplicationService.Insert(new Person("test name", "test remark"));
        }
    }
}
