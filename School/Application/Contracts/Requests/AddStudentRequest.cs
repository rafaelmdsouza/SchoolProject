namespace School.API.Application.Contracts.Requests
{
    public class AddStudentRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
