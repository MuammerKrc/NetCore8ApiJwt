using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.AuthDtos;
using Application.Dtos.UserDtos;
using Domain.AuthEntities;
using Domain.IdentityEntities;

namespace Application.Abstractions.Services
{
	public interface IUserService
	{
		Task<JWTokensDto> CreateUser(CreateUserDto dtos);

	}
}
