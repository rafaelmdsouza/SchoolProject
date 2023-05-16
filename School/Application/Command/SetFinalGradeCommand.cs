using MediatR;
using School.Domain.Aggregates.Student;

namespace School.API.Application.Command
{
    public class SetFinalGradeCommand : IRequest<Student>
    {
        public SetFinalGradeCommand(Guid id, FinalGrade finalGrade)
        {

            FinalGrade = finalGrade;
            Id = id;

        }

        public FinalGrade FinalGrade { get; set; }
        public Guid Id { get; set; }
    }
}
