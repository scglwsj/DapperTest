namespace DapperTest.Common.Models.People
{
    public class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Remark { get; private set; }
        public PersonStatus Status { get; private set; }

        public Person(string name, string remark)
        {
            Name = name;
            Remark = remark;
            Status = PersonStatus.Valid;
        }

        public Person(int id, string name, string remark, PersonStatus status)
        {
            Id = id;
            Name = name;
            Remark = remark;
            Status = status;
        }
    }
}