using System.Collections.Generic;
using DapperTest.Common.Models.People;

namespace DapperTest.Common.Models.Teams
{
    public class Team
    {
        public int Id { get;private set; }
        public string Name { get; private set; }
        public Person Owner { get; private set; }
        public IList<Person> Members { get; private set; }

        public Team(int id, string name, Person owner, IList<Person> members)
        {
            Id = id;
            Name = name;
            Owner = owner;
            Members = members;
        }
    }
}