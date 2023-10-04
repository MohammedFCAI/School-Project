using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Commands.Responses;

namespace SchoolProject.Core.Features.Subjects.Commands.Handlers
{
	public class SubjectHadlerCommand : ResponseHandler, IRequestHandler<AddSubjectCommand, Response<AddSubjectResponse>>,
														 IRequestHandler<UpdateSubjectCommand, Response<UpdateSubjectResponse>>,
														 IRequestHandler<DeleteSubjectCommand, Response<string>>
	{

		private readonly ISubjectService _subjectService;
		private readonly IMapper _mapper;

		public SubjectHadlerCommand(ISubjectService subjectService, IMapper mapper)
		{
			_subjectService = subjectService;
			_mapper = mapper;
		}

		public async Task<Response<AddSubjectResponse>> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
		{
			var subject = _mapper.Map<Subject>(request);

			var addedSubject = await _subjectService.Add(subject);

			if (addedSubject == null)
				return BadRequest<AddSubjectResponse>("Department name is exist..!");

			var subjectMapper = _mapper.Map<AddSubjectResponse>(subject);

			return Created(subjectMapper);
		}

		public async Task<Response<UpdateSubjectResponse>> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
		{
			var foundSubject = await _subjectService.GetById(request.Id);

			if (foundSubject == null)
				return NotFound<UpdateSubjectResponse>("Id not valid..!");

			var subject = _mapper.Map<Subject>(request);

			var updated = await _subjectService.Update(subject);
			if (updated == null)
				return BadRequest<UpdateSubjectResponse>("Subject name is exist..!");

			var subjectMapper = _mapper.Map<UpdateSubjectResponse>(subject);

			return Success(subjectMapper);
		}

		public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
		{
			var foundSubject = await _subjectService.GetById(request.Id);

			if (foundSubject == null)
				return NotFound<string>("Id not valid..!");

			var subject = _mapper.Map<Subject>(request);

			await _subjectService.Delete(subject.SubjectId);

			return Deleted<string>("Deleted Successfully");
		}
	}
}
