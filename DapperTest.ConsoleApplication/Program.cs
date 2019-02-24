using System;
using System.Collections.Generic;
using DapperTest.Common.Interface.ApplicationService;
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
            var teamApplicationService = container.Resolve<ITeamApplicationService>();

//            personApplicationService.Insert(new Person("test name", "test remark"));
//            personApplicationService.Insert(new Person("test name2", "test remark2"));
//            personApplicationService.InsertBulk(new List<Person>
//            {
//                new Person("bulk test name", "bulk test remark"),
//                new Person("bulk test name2", "bulk test remark2")
//            });
            var person = personApplicationService.FindById(2);
            var people = personApplicationService.FindByIds(new List<int> {1, 2, 3});
            Console.WriteLine(person.Name);
//            personApplicationService.Delete(person);

            Console.WriteLine(people[0].Name);
            Console.WriteLine(people[1].Name);

            var team = teamApplicationService.FindByOwnerId(2);
            Console.WriteLine(team.Name);
            Console.WriteLine(team.Owner.Name);

            var team2 = teamApplicationService.FindById(1);
            Console.WriteLine(team2.Name);
            Console.WriteLine(team2.Owner.Name);
            Console.WriteLine(team2.Members[0].Name);
            Console.WriteLine(team2.Members[1].Name);

            Console.WriteLine("按任意键退出");
            Console.Read();
        }
    }
}