namespace SchoolProject.Service.Implementations
{
	public class SubjectService : ISubjectService
	{
		private readonly IUnitOfWork _unitOfWork;

		public SubjectService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Subject> Add(Subject subject)
		{
			var IsExist = await _unitOfWork.SubjectRepository.IsSubjectNameUnique(subject.Name);
			if (IsExist)
				return null;

			var d = subject.Name.ToUpper();
			subject.Name = d;

			return await _unitOfWork.SubjectRepository.AddAsync(subject);
		}

		public async Task<Subject> Delete(int subjectId)
		{
			var subject = await GetById(subjectId);
			await _unitOfWork.SubjectRepository.DeleteAsync(subjectId);
			return subject;
		}

		public async Task<List<Subject>> GetAllList()
		{
			var subjects = await _unitOfWork.SubjectRepository.GetAllAsync();
			return subjects;
		}

		public async Task<Subject> GetById(int subjectId)
		{
			var subject = await _unitOfWork.SubjectRepository.GetByIdAsync(subjectId);
			return subject;
		}

		public async Task<Subject> Update(Subject subject)
		{
			var IsExist = await _unitOfWork.SubjectRepository.IsSubjectNameUnique(subject.Name);
			if (IsExist)
				return null;

			var d = subject.Name.ToUpper();
			subject.Name = d;

			return await _unitOfWork.SubjectRepository.UpdateAsync(subject);
		}
	}
}
