using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Product : BaseModel<Guid>
	{
		public string Name { get; set; }
		public int Stock { get; set; }
		public int Price { get; set; }
	}
}
