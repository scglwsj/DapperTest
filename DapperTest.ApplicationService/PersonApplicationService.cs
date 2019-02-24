using DapperTest.Common.Interface.ApplicationService;
using DapperTest.Common.Interface.Repository;
using DapperTest.Common.Models;
using DapperTest.Common.Models.People;
using Unity;

namespace DapperTest.ApplicationService
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IPersonRepository _personRepository;

        [InjectionConstructor]
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void Insert(Person person)
        {
            _personRepository.Insert(new PersonDo(person));
        }
    }
}