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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureSwagger();
builder.Services.ApplicationRegistrationService(builder.Configuration);
builder.Services.PersistenceRegistrationService(builder.Configuration);
builder.Services.InfrastructureRegistrationService(builder.Configuration);

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
		RoleClaimType = "roles"
	};
});

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
