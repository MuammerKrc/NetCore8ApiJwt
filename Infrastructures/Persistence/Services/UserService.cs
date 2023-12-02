using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Abstractions.Services.BaseServices;
using Application.Dtos.AuthDtos;
using Application.Dtos.UserDtos;
using Application.Exceptions;
using Application.RoleNameProviders;
using AutoMapper;
using Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Services.BaseServices;

namespace Persistence.Services
{
	public class UserService : BaseService, IUserService, IRegisterEndpoint
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly ITokenService _tokenService;

		public UserService(UserManager<AppUser> userManager,
			RoleManager<AppRole> roleManager,
			ITokenService tokenService,
			IMapper mapper,
			IServiceProvider provider) : base(provider)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_tokenService = tokenService;
		}
		public async Task<JWTokensDto> CreateUser(CreateUserDto createUserDto)
		{
			var user = _mapper.Map<AppUser>(createUserDto);
			user.UserName = user.Email;
			var response = await _userManager.CreateAsync(user, createUserDto.Password);
			if (response.Succeeded)
			{
				await _userManager.AddToRoleAsync(user, RoleNameProvider.CustomerRole);
				var roles = await _userManager.GetRolesAsync(user);
				var tokens = _mapper.Map<JWTokensDto>(_tokenService.CreateAccessToken(user, roles.ToList()));
				return tokens;
			}


			throw new Exception("Bir hata meydana geldi.");
		}
		public async Task<JWTokensDto> UserLogin(UserLoginDto loginDto)
		{
			var user = await _userManager.FindByEmailAsync(loginDto.Email);
			if (user == null)
				throw new UserFriendlyExceptions("Bu email ve şifre birbiriyle uyuşmamaktadır.");

			var passwordCheck = await _userManager.CheckPasswordAsync(user, loginDto.Password);

			if (!passwordCheck)
				throw new UserFriendlyExceptions("Bu email ve şifre birbiriyle uyuşmamaktadır.");
			var roles = await _userManager.GetRolesAsync(user);
			return _mapper.Map<JWTokensDto>(_tokenService.CreateAccessToken(user, roles.ToList()));
		}
		public async Task<JWTokensDto> LoginWithRefreshToken(LoginWithRefreshTokenDto refreshTokenDto)
		{
			var userId = _tokenService.ValidateRefreshTokenAndCreateAccessToken(refreshTokenDto.RefreshToken);
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null) throw new UserFriendlyExceptions("Bu kullanıcı bulunamadı");
			var roles = await _userManager.GetRolesAsync(user);
			return _mapper.Map<JWTokensDto>(_tokenService.CreateAccessToken(user, roles.ToList()));
		}
	}
}
