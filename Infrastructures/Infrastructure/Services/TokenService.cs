using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Application.ConfigurationModels;
using Application.Exceptions;
using Domain.AuthEntities;
using Domain.IdentityEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
	public class TokenService : ITokenService
	{
		private readonly TokenConfigurationModels _tokenConfigurationModels;

		public TokenService(IOptions<TokenConfigurationModels> tokenConfigurationModels)
		{
			_tokenConfigurationModels = tokenConfigurationModels.Value;
		}

		private SigningCredentials GetSigningCredentials(string key)
		{
			var keyByte = Encoding.ASCII.GetBytes(key);
			var symmetricKey = new SymmetricSecurityKey(keyByte);
			return new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);


		}

		private string CreateTokenOnSecurityToken(SecurityTokenDescriptor descriptor)
		{
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(descriptor);
			return tokenHandler.WriteToken(token);
		}
		public JWTokens CreateAccessToken(AppUser appUser, List<string> roles)
		{
			SigningCredentials signingCredentials =
				GetSigningCredentials(_tokenConfigurationModels.AccessTokenSecurityKey);



			var claims = roles.Select(i => new Claim(ClaimTypes.Role, i)).ToList();
			claims.AddRange(new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.NameId, appUser.Id.ToString() ?? ""),
				new Claim(JwtRegisteredClaimNames.Name, appUser.Name ?? ""),
				new Claim(JwtRegisteredClaimNames.Email, appUser.Email ?? ""),
				new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
			});
			//JwtSecurityToken tokne= new JwtSecurityToken(issuer:"deneme",expires:DateTime.UtcNow.AddMinutes(2),notBefore:DateTime.Now)
			

			var jwtTokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(claims),
				Audience = _tokenConfigurationModels.Audience,
				SigningCredentials = signingCredentials,
				Issuer = _tokenConfigurationModels.Issuer,
				NotBefore = DateTime.UtcNow,
				Expires = DateTime.UtcNow.AddMinutes(_tokenConfigurationModels.AccessTokenExpirationTime),
			};
			var accessToken = CreateTokenOnSecurityToken(jwtTokenDescriptor);
			var refreshToken = CreateRefreshToken(appUser.Id);
			return new JWTokens() { AccessToken = accessToken, RefreshToken = refreshToken };
		}

		public string CreateRefreshToken(Guid userId)
		{
			var signingCredentials = GetSigningCredentials(_tokenConfigurationModels.RefreshTokenSecurityKey);
			var jwtTokenDescriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(new List<Claim>()
				{
					new Claim(JwtRegisteredClaimNames.NameId,userId.ToString()),
					new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
				}),

				Audience = _tokenConfigurationModels.Audience,
				SigningCredentials = signingCredentials,
				Issuer = _tokenConfigurationModels.Issuer,
				NotBefore = DateTime.UtcNow,
				Expires = DateTime.UtcNow.AddMinutes(_tokenConfigurationModels.RefreshTokenExpirationTime),
			};

			return CreateTokenOnSecurityToken(jwtTokenDescriptor);
		}

		public string ValidateRefreshTokenAndCreateAccessToken(string refreshToken)
		{
			try
			{


				JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
				var response = tokenHandler.ValidateToken(refreshToken, new TokenValidationParameters()
				{
					ValidIssuer = _tokenConfigurationModels.Issuer,
					ValidAudience = _tokenConfigurationModels.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenConfigurationModels.RefreshTokenSecurityKey)),
					ValidateIssuer = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ClockSkew = TimeSpan.Zero,
					NameClaimType = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.NameId,

				}, out _);

				var claimsIdentity = response.Identities.FirstOrDefault(x => x.IsAuthenticated);

				var responseUserId =
					claimsIdentity.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier);
				//we need to check also on database to user registered with this token 
				if (responseUserId == null) throw new Exception("Bir hata meydana geldi");
				return responseUserId.Value;
			}
			catch (Exception e)
			{
				throw new Exception("Bir hata meydana geldi.", e);
			}
		}
	}

}
