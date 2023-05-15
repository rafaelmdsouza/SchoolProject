using MediatR;
using School.API.Application.Queries;
using School.Domain.Aggregates.Student;
using School.Infra;

namespace School.API.Application.Handler.QueriesHandler
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentById, Student>
    {
        private readonly DataContext _dataContext;

        public GetStudentByIdQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Student> Handle(GetStudentById request, CancellationToken cancellationToken)
        {
            return await _dataContext.Students.FindAsync(request.Id, cancellationToken);
        }
    }
}
