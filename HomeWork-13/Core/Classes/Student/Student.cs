using HomeWork_13.Core.Base.Person;
using HomeWork_13.Core.Classes.Univer;
using HomeWork_13.Core.Structs.StudentMetData;

namespace HomeWork_13.Core.Classes.Student
{
    public class Student : Person
    {
        public Student() { }
        public Student(int id, string name, University university, StudentMetData metData) : base(id, name)
        {
            University = university;
        }

        public string? UserName { get; set; }
        public string? Password { get; set; }
        public StudentMetData? StudentMetData { get; set; }
        public University? University { get; set; }
    }
}
