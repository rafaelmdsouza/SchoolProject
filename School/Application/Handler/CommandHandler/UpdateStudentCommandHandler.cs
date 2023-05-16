using MediatR;
using Microsoft.EntityFrameworkCore;
using School.API.Application.Command;
using School.Domain.Aggregates.Student;
using School.Infra;

namespace School.API.Application.Handler.CommandHandler
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly DataContext _context;
        public UpdateStudentCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == request.Id);

            student.Update(request.Phone, request.Email);
            await _context.SaveChangesAsync(cancellationToken);

            return student;

        }
    }
}
