using DapperTest.ApplicationService;
using DapperTest.Common.Interface.ApplicationService;
using DapperTest.Common.Interface.Repository;
using DapperTest.Repository;
using Unity;

namespace DapperTest.ConsoleApplication
{
    public class ContainerRegister
    {
        private static readonly IUnityContainer Container = new UnityContainer();

        public static void InitContainer()
        {
            Container.RegisterType<IPersonApplicationService, PersonApplicationService>();
            Container.RegisterType<IPersonRepository, PersonRepository>();
        }

        public static IUnityContainer GetContainer()
        {
            return Container;
        }
    }
}