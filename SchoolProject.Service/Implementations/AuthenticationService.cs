using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.Repositories;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Service.Implementations
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly JwtSettings _jwtSettings;
		private readonly UserManager<User> _userManger;
		private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreshToken;
		private readonly UnitOfWork _unitOfWork;

		public AuthenticationService(UserManager<User> userManger, IOptions<JwtSettings> jwtSettings, ConcurrentDictionary<string, RefreshToken> userRefreshToken, UnitOfWork unitOfWork)
		{
			_jwtSettings = jwtSettings.Value;
			_userManger = userManger;
			_UserRefreshToken = userRefreshToken;
			_unitOfWork = unitOfWork;
		}

		public async Task<SignInResponse> GetJWTToken(User user)
		{
			var userClaims = await _userManger.GetClaimsAsync(user);
			var roles = await _userManger.GetRolesAsync(user);
			var roleClaims = new List<Claim>();

			foreach (var role in roles)
				roleClaims.Add(new Claim("roles", role));

			var claims = GetClaims(user)
			.Union(userClaims).Union(roleClaims);


			var symmatricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
			var signingCredentials = new SigningCredentials(symmatricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityKey = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.Now.AddDays(_jwtSettings.DurationInDays),
				signingCredentials: signingCredentials);

			var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityKey);

			var refreshToken = GetRefreshToken(user.UserName);

			var userRefreshToken = new UserRefreshToken
			{
				CreatedOn = DateTime.Now,
				ExpireDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
				UserId = user.Id,
				IsUsed = false,
				IsRevoked = false,
				JwtId = jwtSecurityKey.Id,
				RefreshToken = refreshToken.Token,
				Token = accessToken
			};

			await _unitOfWork.RefreshTokenRepository.AddAsync(userRefreshToken);

			return new SignInResponse
			{
				RefreshToken = refreshToken,
				AccessToken = accessToken
			};
		}

		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			var randomNumberGenerate = RandomNumberGenerator.Create();
			randomNumberGenerate.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}

		private RefreshToken GetRefreshToken(string username)
		{
			var refreshToken = new RefreshToken
			{
				ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
				UserName = username,
				Token = GenerateRefreshToken()

			};

			_UserRefreshToken.AddOrUpdate(refreshToken.Token, refreshToken, (s, t) => refreshToken);
			return refreshToken;

		}


		private List<Claim> GetClaims(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id),
				new Claim("PhoneNumber", user.PhoneNumber)
			};

			return claims;
		}
	}
}
