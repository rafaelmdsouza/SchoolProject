using MediatR;
using School.Domain.Aggregates.Student;

namespace School.API.Application.Command
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        public UpdateStudentCommand(Guid id, string phone, string email)
        {
            Id = id;
            Phone = phone;
            Email = email;
        }
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
