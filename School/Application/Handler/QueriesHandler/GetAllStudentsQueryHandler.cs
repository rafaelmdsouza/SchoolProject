using MediatR;
using Microsoft.EntityFrameworkCore;
using School.API.Application.Queries;
using School.Domain.Aggregates.Student;
using School.Infra;

namespace School.API.Application.Handler.QueriesHandler
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudents, IEnumerable<Student>>
    {
        private readonly DataContext _dataContext;
        public GetAllStudentsQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Student>> Handle(GetAllStudents request, CancellationToken cancellationToken)
        {
            var students = await _dataContext.Students.AsNoTracking().Where(s => s.isActive == true).ToListAsync(cancellationToken);
            return students;
        }
    }
}
