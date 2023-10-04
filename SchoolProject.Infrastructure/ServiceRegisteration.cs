using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SchoolProject.Data.Entities.Identities;
using SchoolProject.Data.Helpers;
using System.Text;

namespace SchoolProject.Infrastructure
{
	public static class ServiceRegistration
	{
		public static IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
		{

			// Register to DB
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));


			//JWT Authentication
			// Map
			services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));


			services.AddIdentity<User, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();



			services.Configure<IdentityOptions>(options =>
			{
				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;
				// Lockout settings.
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
				options.Lockout.MaxFailedAccessAttempts = 5;
				options.Lockout.AllowedForNewUsers = true;
				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedEmail = false;
			});




			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(o =>
			{
				o.RequireHttpsMetadata = false;
				o.SaveToken = false;
				o.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidIssuer = configuration["JwtSettings:Issuer"],
					ValidAudience = configuration["JwtSettings:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
				};
			});

			#region Swagger Gn
			//Swagger Gn
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Project", Version = "v1" });
				c.EnableAnnotations();

				c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = JwtBearerDefaults.AuthenticationScheme
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = JwtBearerDefaults.AuthenticationScheme
							}
						},
						Array.Empty<string>()
					}
				});
			});
			#endregion



			return services;
		}

	}
}