using SchoolProject.Core.Features.StudentCourse.Commands.Models;
using SchoolProject.Core.Features.StudentSubjects.Commands.Models;

namespace SchoolProject.Core.Features.StudentCourse.Commands.Handlers
{
	public class StudentSubjectHandlerCommand : ResponseHandler, IRequestHandler<AddStudentSubjectCommand, Response<string>>,
																 IRequestHandler<DeleteStudentSubjectCommand, Response<string>>
	{
		private readonly IStudentService _studentService;
		private readonly ISubjectService _subjectService;
		private readonly IMapper _mapper;
		private readonly IStudentSubjectsService _studentSubjectsService;

		public StudentSubjectHandlerCommand(IStudentService studentService, IMapper mapper, IStudentSubjectsService studentSubjectsService,
			ISubjectService subjectService)
		{
			_studentService = studentService;
			_mapper = mapper;
			_studentSubjectsService = studentSubjectsService;
			_subjectService = subjectService;
		}


		public async Task<Response<string>> Handle(AddStudentSubjectCommand request, CancellationToken cancellationToken)
		{
			var student = await _studentService.GetById(request.StudentId);
			var subject = await _subjectService.GetById(request.SubjectId);

			if (student == null || subject == null)
				return NotFound<string>("Student id or subject id is wrong..!");

			// Mpping: 
			var studentSubject = _mapper.Map<StudentSubject>(request);

			var result = await _studentSubjectsService.AddSubjectToStudent(studentSubject.StudentId, studentSubject.SubjectId);

			if (result == "SubjectIsExist")
				return Empty<string>("Course is assigned to this student before..! You can't add it again..");

			if (result == "NotAllowed")
				return BadRequest<string>("This course is not allowed for you..");

			return Created("Course Added");
		}

		public async Task<Response<string>> Handle(DeleteStudentSubjectCommand request, CancellationToken cancellationToken)
		{

			var flag = await _studentSubjectsService.DeleteStudentSubject(request.StudentId, request.SubjectId);

			if (flag == "StudentIsNull")
				return BadRequest<string>("Student id is not found..!");

			else if (flag == "SubjectIsNull")
				return BadRequest<string>("Subject id is not found..!");


			else if (flag == "false")
				return BadRequest<string>("Error in student id or subject id..!");

			else if (flag == "Empty")
				return NotFound<string>("Student dosen't has courses..!");

			else if (flag == "CourseNotFound")
				return NotFound<string>($"Student dosen't has course id: {request.SubjectId}");

			return Deleted<string>("Deleted..");
		}
	}
}
