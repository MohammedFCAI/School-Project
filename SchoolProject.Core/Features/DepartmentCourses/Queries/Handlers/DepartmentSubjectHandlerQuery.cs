using SchoolProject.Core.Features.DepartmentCourses.Queries.Models;
using SchoolProject.Core.Features.DepartmentCourses.Queries.Responses;

namespace SchoolProject.Core.Features.DepartmentCourses.Queries.Handlers
{
	public class DepartmentSubjectHandlerQuery : ResponseHandler, IRequestHandler<GetSubjectsForDepartmentQuery, Response<List<GetDepartmentSubjectListResponse>>>
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentService _departmentService;
		private readonly IDepartmentSubjectsService _departmentSubjectsService;

		public DepartmentSubjectHandlerQuery(IMapper mapper, IDepartmentService departmentService, IDepartmentSubjectsService departmentSubjectsService)
		{
			_mapper = mapper;
			_departmentService = departmentService;
			_departmentSubjectsService = departmentSubjectsService;
		}

		public async Task<Response<List<GetDepartmentSubjectListResponse>>> Handle(GetSubjectsForDepartmentQuery request, CancellationToken cancellationToken)
		{
			var department = await _departmentService.GetById(request.Id);

			if (department == null)
				return NotFound<List<GetDepartmentSubjectListResponse>>("Id not found..!");

			var departmentSubjects = await _departmentSubjectsService.GetDepartmentSubjects(request.Id);

			if (departmentSubjects.Count == 0)
				return Empty<List<GetDepartmentSubjectListResponse>>("departments are empty..");

			// Mapping:

			var departmentSubjectMapper = _mapper.Map<List<GetDepartmentSubjectListResponse>>(departmentSubjects);




			return Success(departmentSubjectMapper);
		}
	}
}
