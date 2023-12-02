using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoleNameProviders
{
	public static class RoleNameProvider
	{
		public static string Deneme
		{
			get;
			set;
		} = "deme";
		//adminRole
		public static string AdminRole = "AdminRole";

		//customerRole
		public static string CustomerRole = "CustomerRole";
	}
}
