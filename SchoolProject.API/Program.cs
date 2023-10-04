using Microsoft.EntityFrameworkCore;
using SchoolProject.Core;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register to DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

// Add Dependency Injection
builder.Services.AddInfrastructureDependencies().AddServiceDependencies().AddCoreDependencies().AddServiceRegistration();

#region Security
//builder.Services.AddIdentity<User, IdentityRole>(options =>
//{
//	options.SignIn.RequireConfirmedEmail = true;
//}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

//builder.Services.Configure<IdentityOptions>(options =>
//{
//	// Password settings.
//	options.Password.RequireDigit = true;
//	options.Password.RequireLowercase = true;
//	options.Password.RequireNonAlphanumeric = true;
//	options.Password.RequireUppercase = true;
//	options.Password.RequiredLength = 6;
//	options.Password.RequiredUniqueChars = 1;
//	// Lockout settings.
//	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//	options.Lockout.MaxFailedAccessAttempts = 5;
//	options.Lockout.AllowedForNewUsers = true;
//	// User settings.
//	options.User.AllowedUserNameCharacters =
//	"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//	options.User.RequireUniqueEmail = false;
//}); 
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// CORS
var CORS = "_cors";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: CORS,
	policy =>
	{
		policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
	});
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();