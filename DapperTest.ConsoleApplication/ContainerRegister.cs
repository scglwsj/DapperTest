using DapperTest.ApplicationService;
using DapperTest.Common.Interface.ApplicationService;
using DapperTest.Common.Interface.Repository;
using DapperTest.Repository;
using Unity;

namespace DapperTest.ConsoleApplication
{
    public class ContainerRegister
    {
        public static void InitContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IPersonApplicationService, PersonApplicationService>();
            container.RegisterType<IPersonRepository, PersonRepository>();
        }
    }
}