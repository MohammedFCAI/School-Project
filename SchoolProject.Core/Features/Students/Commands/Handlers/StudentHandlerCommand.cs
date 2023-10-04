namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
	public class StudentHandlerCommand : ResponseHandler, IRequestHandler<AddStudentCommand, Response<AddStudentResponse>>,
										 IRequestHandler<UpdateStudentCommand, Response<UpdateStudentResponse>>,
										 IRequestHandler<DeleteStudentCommand, Response<string>>

	{
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;


		public StudentHandlerCommand(IStudentService studentService, IMapper mapper)
		{
			_studentService = studentService;
			_mapper = mapper;

		}

		public async Task<Response<AddStudentResponse>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
		{
			var student = _mapper.Map<Student>(request);

			await _studentService.Add(student);

			var studentMapper = _mapper.Map<AddStudentResponse>(student);

			return Created(studentMapper);
		}

		public async Task<Response<UpdateStudentResponse>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
		{
			var validStudent = await _studentService.GetById(request.Id);
			if (validStudent == null)
				return NotFound<UpdateStudentResponse>("Id is not found..!");

			var student = _mapper.Map<Student>(request);

			await _studentService.Update(student);

			var studentMapper = _mapper.Map<UpdateStudentResponse>(student);

			return Success(studentMapper);
		}

		public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var validStudent = await _studentService.GetById(request.Id);
			if (validStudent == null)
				return NotFound<string>("Id is not found..!");

			var student = _mapper.Map<Student>(request);

			await _studentService.Delete(student.StudentId);

			return Deleted<string>("Deleted..!");
		}



	}
}
