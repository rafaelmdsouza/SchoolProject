using MediatR;
using School.Domain.Aggregates.Student;

namespace School.API.Application.Command
{
    public class AddStudentCommand : IRequest<Student>
    {
        public AddStudentCommand(string firstName, string lastName, int age, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Phone = phone;
            Email = email;

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
