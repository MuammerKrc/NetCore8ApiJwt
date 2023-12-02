using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntities
{
	public class BaseModel<TKey> : IBaseModel
	{
		public TKey Id { get; set; }
		public bool SoftDeleted { get; set; } = false;
	}
}
