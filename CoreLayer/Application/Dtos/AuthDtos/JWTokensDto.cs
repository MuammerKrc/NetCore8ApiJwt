using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.AuthDtos
{
	public class JWTokensDto
	{
		public string AccessToken { get; set; }
		public string RefreshToken { get; set; }
	}
}
