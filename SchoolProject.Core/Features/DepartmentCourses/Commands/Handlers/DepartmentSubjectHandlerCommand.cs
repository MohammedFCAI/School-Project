using SchoolProject.Core.Features.DepartmentCourses.Commands.Models;

namespace SchoolProject.Core.Features.DepartmentCourses.Commands.Handlers
{
	public class DepartmentSubjectHandlerCommand : ResponseHandler, IRequestHandler<AddDepartmentSubjectCommand, Response<string>>,
																	IRequestHandler<DeleteDepartmentSubjectCommand, Response<string>>
	{

		private readonly IDepartmentService _departmentService;
		private readonly ISubjectService _subjectService;
		private readonly IMapper _mapper;
		private readonly IDepartmentSubjectsService _departmentSubjectsService;

		public DepartmentSubjectHandlerCommand(IDepartmentService departmentService, ISubjectService subjectService, IMapper mapper, IDepartmentSubjectsService departmentSubjectsService)
		{
			_departmentService = departmentService;
			_subjectService = subjectService;
			_mapper = mapper;
			_departmentSubjectsService = departmentSubjectsService;
		}

		public async Task<Response<string>> Handle(AddDepartmentSubjectCommand request, CancellationToken cancellationToken)
		{
			var department = await _departmentService.GetById(request.DepartmentId);
			var subject = await _subjectService.GetById(request.SubjectId);

			if (department == null || subject == null)
				return NotFound<string>("Deparment id or subject id is wrong..!");

			// Mpping: 
			var departmentSubject = _mapper.Map<DepartmentSubject>(request);

			var result = await _departmentSubjectsService.AddSubjectToDepartment(departmentSubject.DepartmentId, departmentSubject.SubjectId);

			if (result == null)
				return BadRequest<string>("Course is assigned to this department before..! You can't add it again..");

			return Created("Course Added");
		}

		public async Task<Response<string>> Handle(DeleteDepartmentSubjectCommand request, CancellationToken cancellationToken)
		{
			var flag = await _departmentSubjectsService.DeleteDepartmentSubject(request.DepartmentId, request.SubjectId);

			if (flag == "DepartmentIsNull")
				return BadRequest<string>("Department id is not found..!");

			else if (flag == "SubjectIsNull")
				return BadRequest<string>("Course id is not found..!");


			else if (flag == "false")
				return BadRequest<string>("Error in Department id or course id..!");

			else if (flag == "Empty")
				return NotFound<string>("Department dosen't has courses..!");

			else if (flag == "CourseNotFound")
				return NotFound<string>($"Department dosen't has course id: {request.SubjectId}");

			return Deleted<string>("Deleted..");
		}
	}
}
