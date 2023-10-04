using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identities;
using SchoolProject.Data.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Service.Implementations
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly JwtSettings _jwtSettings;
		private readonly UserManager<User> _userManger;

		public AuthenticationService(UserManager<User> userManger, IOptions<JwtSettings> jwtSettings)
		{
			_jwtSettings = jwtSettings.Value;
			_userManger = userManger;
		}

		public async Task<string> GetJWTToken(User user)
		{
			var userClaims = await _userManger.GetClaimsAsync(user);
			var roles = await _userManger.GetRolesAsync(user);
			var roleClaims = new List<Claim>();

			foreach (var role in roles)
				roleClaims.Add(new Claim("roles", role));

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id),
				new Claim("PhoneNumber", user.PhoneNumber)
			}
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


			return accessToken;
		}


	}
}
