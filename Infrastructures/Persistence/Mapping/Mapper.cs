using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.AuthDtos;
using Application.Dtos.UserDtos;
using AutoMapper;
using AutoMapper.Internal;
using Domain.AuthEntities;
using Domain.IdentityEntities;

namespace Persistence.Mapping
{
	public class Mapper : Profile
	{
		public Mapper()
		{
			CreateMap<CreateUserDto, AppUser>().ReverseMap();
			CreateMap<UserDto, AppUser>().ReverseMap();
			CreateMap<JWTokensDto, JWTokens>().ReverseMap();
		}
	}
}
