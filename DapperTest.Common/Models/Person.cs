using DapperTest.Common.Enumerations;

namespace DapperTest.Common.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public PersonStatus Status { get; set; }
    }
}