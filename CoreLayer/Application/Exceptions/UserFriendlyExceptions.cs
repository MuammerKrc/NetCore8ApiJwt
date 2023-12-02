using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
	public class UserFriendlyExceptions : Exception
	{
		public UserFriendlyExceptions() : base("Bir hata meydana geldi!")
		{
		}

		public UserFriendlyExceptions(string? message) : base(message)
		{
		}

		public UserFriendlyExceptions(string? message, Exception? innerException) : base(message, innerException)
		{

		}

	}
}
