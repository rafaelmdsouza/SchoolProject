using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.API.Application.Command;
using School.API.Application.Contracts.Requests;
using School.API.Application.Contracts.Responses;
using School.API.Application.Queries;
using School.Domain.Aggregates.Student;
using School.Infra;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public SchoolController(IMediator mediator, DataContext dataContext, IMapper mapper)
        {
            _mediator = mediator;
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("students")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStudents()
        {
            var command = new GetAllStudents();
            var response =  await _mediator.Send(command);
            var students = _mapper.Map<List<StudentResponse>>(response);

            return Ok(students);
        }

        [HttpGet]
        [Route("students/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = _dataContext.Students.Any(s => s.Id == id);
            if(student == null)
            {
                return NotFound();
            }

            var command = new GetStudentById(id);
            var response = await _mediator.Send(command);
            var studentResponse = _mapper.Map<FullStudentResponse>(response);

            return Ok(studentResponse);
        }

        [HttpPost]
        [Route("students")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentRequest student)
        {
            var command = _mapper.Map<AddStudentCommand>(student);

            var response = await _mediator.Send(command);

            var studentResponse = _mapper.Map<StudentResponse>(response);

            return CreatedAtAction(nameof(GetStudentById), new { id = response.Id}, studentResponse);
        }

        [HttpPost]
        [Route("students/{id}/setfinalgrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SetFinalGrade(Guid id, [FromBody]FinalGradeRequest finalGrade)
        {
            var command = new SetFinalGradeCommand(id, finalGrade.FinalGrade);
            var response = await _mediator.Send(command);
            var studentResponse = _mapper.Map<FullStudentResponse>(response);

            return Ok(studentResponse);
        }

    }
}
