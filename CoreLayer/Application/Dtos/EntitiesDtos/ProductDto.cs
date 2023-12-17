using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.EntitiesDtos
{
	public class ProductDto : BaseModel<Guid>
	{
		public string Name { get; set; }
		public int Stock { get; set; }
		public int Price { get; set; }
	}
}
