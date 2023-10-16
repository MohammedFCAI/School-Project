using SchoolProject.Data.Entities.Identities;

namespace SchoolProject.Infrastructure.Repositories
{
	public class RefreshTokenRepository : IRefreshTokenRepository
	{

		private readonly ApplicationDbContext _context;

		public RefreshTokenRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<UserRefreshToken> AddAsync(UserRefreshToken token)
		{
			await _context.UserRefreshTokens.AddAsync(token);
			await _context.SaveChangesAsync();
			return token;
		}

		public async Task<UserRefreshToken> DeleteAsync(int tokenId)
		{
			var refreshToken = await GetByIdAsync(tokenId);
			_context.UserRefreshTokens.Remove(refreshToken);
			await _context.SaveChangesAsync();
			return refreshToken;
		}

		public async Task<List<UserRefreshToken>> GetAllAsync() =>
			await _context.UserRefreshTokens.AsNoTracking().ToListAsync();

		public async Task<UserRefreshToken> GetByIdAsync(int tokenId) =>
			await _context.UserRefreshTokens.AsNoTracking().FirstOrDefaultAsync(i => i.Id == tokenId);

		public async Task<UserRefreshToken> UpdateAsync(UserRefreshToken token)
		{
			_context.UserRefreshTokens.Update(token);
			await _context.SaveChangesAsync();
			return token;
		}
	}
}
