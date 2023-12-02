using ApiLayer.EnpointBuilder;
using Application;
using Infrastructure;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ApplicationRegistrationService(builder.Configuration);
builder.Services.PersistenceRegistrationService(builder.Configuration);
builder.Services.InfrastructureRegistrationService(builder.Configuration);

builder.Services.AddAuthentication("")

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.BuildAllAndPoints();
app.Run();
