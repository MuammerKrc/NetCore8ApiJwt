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



			var claims = roles.Select(i => new Claim("roles", i)).ToList();
			claims.AddRange(new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.NameId, appUser.Id.ToString() ?? ""),
				new Claim(JwtRegisteredClaimNames.Name, appUser.Name ?? ""),
				new Claim(JwtRegisteredClaimNames.Email, appUser.Email ?? ""),
				new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
			});


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
	}

}
