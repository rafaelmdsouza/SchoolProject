using MediatR;
using School.API.Application.Command;
using School.Domain.Aggregates.Student;
using School.Infra;

namespace School.API.Application.Handler.CommandHandler
{
    public class SetFinalGradeCommandHandler : IRequestHandler<SetFinalGradeCommand, bool>
    {
        private readonly DataContext _context;
        public SetFinalGradeCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(SetFinalGradeCommand request, CancellationToken cancellationToken)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == request.Id);

            student.SetFinalGrade(request.FinalGrade);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
