using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Core.Features.Subjects.Queries.Responses;

namespace SchoolProject.Core.Features.Subjects.Queries.Handlers
{
	public class SubjectHandlerQuery : ResponseHandler, IRequestHandler<GetSubjectListQuery, Response<List<GetSubjectListResponse>>>,
														IRequestHandler<GetSubjectByIdQuery, Response<GetSubjectByIdResponse>>
	{
		private readonly ISubjectService _subjectService;
		private readonly IMapper _mapper;

		public SubjectHandlerQuery(ISubjectService subjectService, IMapper mapper)
		{
			_subjectService = subjectService;
			_mapper = mapper;
		}

		public async Task<Response<List<GetSubjectListResponse>>> Handle(GetSubjectListQuery request, CancellationToken cancellationToken)
		{
			var subjects = await _subjectService.GetAllList();

			if (subjects.Count == 0)
				return NotFound<List<GetSubjectListResponse>>("subjects are empty");
			// Mapping:
			var subjectsMapper = _mapper.Map<List<GetSubjectListResponse>>(subjects);

			return Success(subjectsMapper);
		}

		public async Task<Response<GetSubjectByIdResponse>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
		{
			var subject = await _subjectService.GetById(request.Id);

			if (subject == null)
				return NotFound<GetSubjectByIdResponse>("Id not found");

			// Mapping:
			var subjectMapper = _mapper.Map<GetSubjectByIdResponse>(subject);

			return Success(subjectMapper);
		}
	}
}
