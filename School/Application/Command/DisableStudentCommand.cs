using MediatR;
using School.Domain.Aggregates.Student;

namespace School.API.Application.Command
{
    public class DisableStudentCommand : IRequest<Student>
    {
        public DisableStudentCommand(Guid id)
        {
            Id =id;
        }
        public Guid Id { get; set; }
    }
}
