using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.UserDtos
{
	public class CreateUserDto
	{
		public string Password { get; set; }
		public string Email { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
	}
}
