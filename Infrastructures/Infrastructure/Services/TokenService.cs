using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Services;
using Domain.AuthEntities;
using Domain.IdentityEntities;

namespace Infrastructure.Services
{
	public class TokenService : ITokenService
	{
		public JWTokens CreateAccessToken(AppUser appUser)
		{
			throw new NotImplementedException();
		}
	}
}
