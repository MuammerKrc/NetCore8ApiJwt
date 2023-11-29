using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConfigurationModels
{
	public class TokenConfigurationModels
	{
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public string AccessTokenSecurityKey { get; set; }
		public string RefreshTokenSecurityKey { get; set; }

		public int AccessTokenExpirationTime { get; set; }
		public int RefreshTokenExpirationTime { get; set; }
	}
}
