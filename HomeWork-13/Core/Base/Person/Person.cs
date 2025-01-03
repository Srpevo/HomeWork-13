namespace HomeWork_13.Core.Base.Person
{
    public abstract class Person
    {
        public Person() { }
        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
