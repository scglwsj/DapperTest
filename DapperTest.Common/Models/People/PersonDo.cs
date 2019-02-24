namespace DapperTest.Common.Models.People
{
    public class PersonDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public byte Status { get; set; }

        public PersonDo()
        {
        }

        public PersonDo(Person p)
        {
            Id = p.Id;
            Name = p.Name;
            Remark = p.Remark;
            Status = (byte) p.Status;
        }

        public Person ConvertToPerson()
        {
            return new Person(Id, Name, Remark, (PersonStatus) Status);
        }
    }
}