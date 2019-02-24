using System.Collections.Generic;
using System.Linq;
using DapperTest.Common.Interface.ApplicationService;
using DapperTest.Common.Interface.Repository;
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

        public void InsertBulk(IReadOnlyList<Person> people)
        {
            _personRepository.InsertBulk(people.Select(p => new PersonDo(p)).ToList());
        }

        public Person FindById(int id)
        {
            return _personRepository.FindById(id).ConvertToPerson();
        }

        public IList<Person> FindByIds(IReadOnlyList<int> ids)
        {
            return _personRepository.FindByIds(ids).Select(p => p.ConvertToPerson()).ToList();
        }
    }
}