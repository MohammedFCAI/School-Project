using SchoolProject.Core;
using SchoolProject.Infrastructure;
using SchoolProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Dependency Injection
builder.Services.AddInfrastructureDependencies().AddServiceDependencies().AddCoreDependencies().AddServiceRegistration(builder.Configuration);


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();