using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ApiLayer.EnpointBuilder;
using Application;
using Application.ConfigurationModels;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;
using ApiLayer.SwaggerConfigurations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSwagger();
builder.Services.ApplicationRegistrationService(builder.Configuration);
builder.Services.PersistenceRegistrationService(builder.Configuration);
builder.Services.InfrastructureRegistrationService(builder.Configuration);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllCors",
		builder =>
		{
			builder.AllowAnyHeader();
			builder.AllowAnyMethod();
			builder.AllowAnyOrigin();
		});
});

builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
{
	TokenConfigurationModels model = builder.Configuration.GetSection("Token").Get<TokenConfigurationModels>();
	var keyByte = Encoding.ASCII.GetBytes(model.AccessTokenSecurityKey);
	var symmetricKey = new SymmetricSecurityKey(keyByte);

	opts.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidIssuer = model.Issuer,
		ValidAudience = model.Audience, //ne gibi izinler verilmiş ona göre seçiyor 
		IssuerSigningKey = symmetricKey,

		ValidateIssuerSigningKey = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuer = true,

		ClockSkew = TimeSpan.FromSeconds(10),
		NameClaimType = ClaimTypes.NameIdentifier,
		RoleClaimType = ClaimTypes.Role
	};
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddStaticRolesConfigurationExtensions();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger(
		options =>
		{
		} );
	app.UseSwaggerUI(options =>
	{
	
	} );
	
}


app.UseCors("AllowAllCors");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.BuildAllAndPoints();
app.Run();
