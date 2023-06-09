﻿using AutoMapper;
using School.API.Application.Command;
using School.API.Application.Contracts.Requests;
using School.API.Application.Contracts.Responses;
using School.Domain.Aggregates.Student;

namespace School.API.Application.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddStudentRequest, AddStudentCommand>().ReverseMap();
            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Student, FullStudentResponse>().ReverseMap();
        }
    }
}
