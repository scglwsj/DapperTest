using System.Collections.Generic;
using System.Linq;
using DapperTest.Common.Models.People;

namespace DapperTest.Common.Models.Teams
{
    public class TeamDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonDo Owner { get; set; }
        public IList<PersonDo> Members { get; set; }

        public Team ConvertToTeam()
        {
            return new Team(Id, Name, Owner.ConvertToPerson(), Members?.Select(p => p.ConvertToPerson()).ToList());
        }
    }
}