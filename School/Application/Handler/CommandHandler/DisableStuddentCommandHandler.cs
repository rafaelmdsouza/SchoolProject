using MediatR;
using Microsoft.EntityFrameworkCore;
using School.API.Application.Command;
using School.Domain.Aggregates.Student;
using School.Infra;

namespace School.API.Application.Handler.CommandHandler
{
    public class DisableStuddentCommandHandler : IRequestHandler<DisableStudentCommand, Student>
    {
        private readonly DataContext _context;
        public DisableStuddentCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Student> Handle(DisableStudentCommand request, CancellationToken cancellationToken)
        {
            var student =  _context.Students.FirstOrDefault(s => s.Id == request.Id);
            student.DisableStudent();

            await _context.SaveChangesAsync(cancellationToken);
            return student;
        }
    }
}
