namespace SchoolProject.Core.Features.Departments.Commands.Handlers
{
	public class DepartmentHandlerCommand : ResponseHandler, IRequestHandler<AddDepartmentCommand, Response<AddDepartmentResponse>>,
															 IRequestHandler<UpdateDepartmentCommand, Response<UpdateDepartmentResponse>>,
															 IRequestHandler<DeleteDepartmentCommand, Response<string>>
	{
		private readonly IDepartmentService _departmentService;
		private readonly IMapper _mapper;

		public DepartmentHandlerCommand(IDepartmentService departmentService, IMapper mapper)
		{
			_departmentService = departmentService;
			_mapper = mapper;
		}

		public async Task<Response<AddDepartmentResponse>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
		{
			var department = _mapper.Map<Department>(request);

			var AddedDepartment = await _departmentService.Add(department);

			if (AddedDepartment == null)
				return BadRequest<AddDepartmentResponse>("Department name is exist..!");

			var departmentMapper = _mapper.Map<AddDepartmentResponse>(department);

			return Created(departmentMapper);
		}

		public async Task<Response<UpdateDepartmentResponse>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
		{
			var foundDepartment = await _departmentService.GetById(request.Id);

			if (foundDepartment == null)
				return NotFound<UpdateDepartmentResponse>("Id not valid..!");

			var department = _mapper.Map<Department>(request);

			var updated = await _departmentService.Update(department);
			if (updated == null)
				return BadRequest<UpdateDepartmentResponse>("Department name is exist..!");

			var departmentMapper = _mapper.Map<UpdateDepartmentResponse>(department);

			return Success(departmentMapper);
		}

		public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
		{
			var foundDepartment = await _departmentService.GetById(request.Id);

			if (foundDepartment == null)
				return NotFound<string>("Id not found..!");

			var department = _mapper.Map<Department>(request);

			var result = await _departmentService.Delete(department.DepartmentId);

			if (result == null)
				return BadRequest<string>("You can't delete department..!");

			return Deleted<string>("Deleted Successfully");
		}
	}
}