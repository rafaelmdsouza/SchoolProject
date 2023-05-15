using MediatR;
using School.Domain.Aggregates.Student;

namespace School.API.Application.Queries
{
    public class GetAllStudents : IRequest<IEnumerable<Student>>
    {
    }
}
