namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
	public class StudentHandlerQuery : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
														IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>,
														IRequestHandler<GetStudentsByDepartmentNameQuery, Response<List<GetStudentByDepartmentNameResponse>>>
	{
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;

		public StudentHandlerQuery(IStudentService studentService, IMapper mapper)
		{
			_studentService = studentService;
			_mapper = mapper;
		}

		public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
		{
			var studentList = await _studentService.GetAllList();

			var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);

			return Success(studentListMapper);
		}

		public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
		{
			var student = await _studentService.GetById(request.Id);

			if (student == null)
				return NotFound<GetStudentByIdResponse>("Id not found");

			var studentMapper = _mapper.Map<GetStudentByIdResponse>(student);

			return Success(studentMapper);
		}

		public async Task<Response<List<GetStudentByDepartmentNameResponse>>> Handle(GetStudentsByDepartmentNameQuery request, CancellationToken cancellationToken)
		{
			var students = _studentService.GetSudentsByDepartmentName(request.Name);


			if (students == null)
				return NotFound<List<GetStudentByDepartmentNameResponse>>("Invalid department name..!");

			if (students.Count == 0)
				return NotFound<List<GetStudentByDepartmentNameResponse>>("No students in this department");

			// Mapping:
			var studentsMapper = _mapper.Map<List<GetStudentByDepartmentNameResponse>>(students);

			return Success(studentsMapper);

		}
	}
}
