using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PaginationEntities
{
	public class Pagination
	{
		public int PageIndex { get; set; } = 1;
		public int TotalCount { get; set; } = 10;
	}
}
