using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Aggregates.Student
{
    public class Student
    {
        private Student() {}

        public Student(string firstName, string lastName, int age, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Phone = phone;
            Email = email;
            DataMatricula = DateTime.UtcNow;
            isActive = true;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public DateTime DataMatricula { get; private set; }
        public FinalGrade? FinalGrade { get; private set; }
        public bool isActive { get; private set; }

        public void SetFinalGrade (FinalGrade grade)
        {
            FinalGrade = grade;
        }

        public void DisableStudent ()
        {
            isActive = false;
        }

        public void ActivateStudent()
        {
            isActive = true;
        }

        public void Update(string phone, string email)
        {
            Phone = phone;
            Email = email;
        }
    }
}
