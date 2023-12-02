using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application.Exceptions
{
	public class UserNotFoundExceptions : Exception
	{
		public UserNotFoundExceptions() : base("Böyle bir kullanıcı bulunamadı")
		{
		}

		public UserNotFoundExceptions(string? message) : base(message)
		{
		}

		public UserNotFoundExceptions(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
