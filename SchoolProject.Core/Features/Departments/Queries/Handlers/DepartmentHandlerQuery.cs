namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
	public class DepartmentHandlerQuery : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
														   IRequestHandler<GetDepartmentsListQuery, Response<List<GetDepartmentsListResponse>>>
	{
		private readonly IDepartmentService _departmentService;
		private readonly IMapper _mapper;

		public DepartmentHandlerQuery(IDepartmentService departmentService, IMapper mapper)
		{
			_departmentService = departmentService;
			_mapper = mapper;
		}

		public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
		{
			var department = await _departmentService.GetById(request.Id);

			if (department == null)
				return NotFound<GetDepartmentByIdResponse>("Id not found");

			// Mapping:
			var departmentMapper = _mapper.Map<GetDepartmentByIdResponse>(department);

			return Success(departmentMapper);
		}

		public async Task<Response<List<GetDepartmentsListResponse>>> Handle(GetDepartmentsListQuery request, CancellationToken cancellationToken)
		{
			var departments = await _departmentService.GetAllList();

			if (departments.Count == 0)
				return NotFound<List<GetDepartmentsListResponse>>("departments are not found");
			// Mapping:
			var departmentsMapper = _mapper.Map<List<GetDepartmentsListResponse>>(departments);

			return Success(departmentsMapper);
		}
	}
}
