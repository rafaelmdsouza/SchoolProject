using School.Domain.Aggregates.Student;

namespace School.API.Application.Contracts.Responses
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public FinalGrade? FinalGrade { get; set; }
    }
}
