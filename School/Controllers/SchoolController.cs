using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.API.Application.Command;
using School.API.Application.Contracts.Requests;
using School.API.Application.Contracts.Responses;
using School.API.Application.Queries;
using School.API.Validators;
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
        private readonly StudentValidator _validationRules;
        public SchoolController(IMediator mediator, DataContext dataContext, IMapper mapper, StudentValidator validationRules)
        {
            _mediator = mediator;
            _dataContext = dataContext;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        [HttpGet]
        [Route("students")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStudents()
        {
            var response =  await _mediator.Send(new GetAllStudents());
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

            if (!student)
            {
                return NotFound();
            }

            var cmd = await _mediator.Send(new GetStudentById(id));
            var studentResponse = _mapper.Map<FullStudentResponse>(cmd);

            return Ok(studentResponse);
        }

        [HttpPost]
        [Route("students")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentRequest request)
        {
            var command = _mapper.Map<AddStudentCommand>(request);

            var validator = _validationRules.Validate(command);
            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            var cmd = await _mediator.Send(command);
            if (cmd == null)
                return BadRequest();

            var studentResponse = _mapper.Map<StudentResponse>(cmd);

            return CreatedAtAction(nameof(GetStudentById), new { id = cmd.Id}, studentResponse);
        }

        [HttpPut]
        [Route("students/{id}/update_info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentRequest request)
        {
            var student = _dataContext.Students.Any(s => s.Id == id);
            if (!student)
            {
                return NotFound();
            }

            var cmd = await _mediator.Send(new UpdateStudentCommand(id, request.Phone, request.Email));
            if (cmd == null)
                return BadRequest();

            var studentResponse = _mapper.Map<StudentResponse>(cmd);

            return Ok(studentResponse);
        }

        [HttpPut]
        [Route("students/{id}/disable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DisableStudent(Guid id)
        {
            var student = _dataContext.Students.Any(s => s.Id == id);
            if (!student)
            {
                return NotFound();
            }

            var cmd = await _mediator.Send(new DisableStudentCommand(id));
            if (cmd == null)
                return BadRequest();

            var studentResponse = _mapper.Map<FullStudentResponse>(cmd);

            return Ok(studentResponse);
        }

        [HttpPost]
        [Route("students/{id}/setfinalgrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SetFinalGrade(Guid id, [FromBody]FinalGradeRequest request)
        {
            var cmd = await _mediator.Send(new SetFinalGradeCommand(id, request.FinalGrade));
            if (cmd == null)
                return BadRequest();

            var studentResponse = _mapper.Map<StudentResponse>(cmd);

            return Ok(studentResponse);
        }

    }
}
