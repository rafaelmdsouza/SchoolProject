using MediatR;
using School.Domain.Aggregates.Student;

namespace School.API.Application.Queries
{
    public class GetStudentById : IRequest<Student>
    {
        public GetStudentById(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
