using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dtos.AuthDtos;
using Application.Dtos.EntitiesDtos;
using Application.Dtos.UserDtos;
using AutoMapper;
using AutoMapper.Internal;
using Domain.AuthEntities;
using Domain.Entities;
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
			CreateMap<ProductDto, Product>().ReverseMap();
		}
	}
}
