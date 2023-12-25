using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomAttributes
{
	public class AuthrizeDefinitionAttribute : Attribute
	{
		public string Menu { get; set; }
		public string Definition { get; set; }


	}
}
