namespace HomeWork_13.Core.Classes.Univer
{
    public class University
    {
        public University() { }
        public University(string name, string description = "no description")
        {
            Name = name;
            Description = description;
        }

        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
