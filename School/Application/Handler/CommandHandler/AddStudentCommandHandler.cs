﻿using MediatR;
using School.API.Application.Command;
using School.Domain.Aggregates.Student;
using School.Infra;

namespace School.API.Application.Handler.CommandHandler
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly DataContext _dataContext;

        public AddStudentCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.FirstName, request.LastName, request.Age,request.Phone, request.Email);

             _dataContext.Add(student);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return student;
        }
    }
}
