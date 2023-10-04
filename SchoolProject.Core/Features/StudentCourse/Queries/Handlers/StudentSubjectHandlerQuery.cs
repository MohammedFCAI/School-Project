using SchoolProject.Core.Features.StudentCourse.Queries.Models;
using SchoolProject.Core.Features.StudentCourse.Queries.Responses;

namespace SchoolProject.Core.Features.StudentCourse.Queries.Handlers
{
	public class StudentSubjectHandlerQuery : ResponseHandler, IRequestHandler<GetSubjectsForStudentQuery, Response<List<GetStudentSubjectListResponse>>>



	{
		private readonly IMapper _mapper;
		private readonly IStudentService _studentService;
		private readonly IStudentSubjectsService _studentSubjectsService;

		public StudentSubjectHandlerQuery(IMapper mapper, IStudentSubjectsService studentSubjectsService, IStudentService studentService)
		{
			_mapper = mapper;
			_studentSubjectsService = studentSubjectsService;
			_studentService = studentService;
		}

		public async Task<Response<List<GetStudentSubjectListResponse>>> Handle(GetSubjectsForStudentQuery request, CancellationToken cancellationToken)
		{
			//var student = await _studentSubjectsService.GetStudentSubject(request.Id);
			var student = await _studentService.GetById(request.Id);

			if (student == null)
				return NotFound<List<GetStudentSubjectListResponse>>("Id not found..!");

			var studentSubjects = await _studentSubjectsService.GetStudentSubject(request.Id);

			// Mapping:

			var studentSubjectMapper = _mapper.Map<List<GetStudentSubjectListResponse>>(studentSubjects);

			return Success(studentSubjectMapper);

		}


	}
}
