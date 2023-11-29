using Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AuthEntities;

namespace Application.Abstractions.Services
{
	public interface ITokenService
	{
		JWTokens CreateAccessToken(AppUser appUser, List<string> roles);
		string CreateRefreshToken(Guid userId);

	}
}
