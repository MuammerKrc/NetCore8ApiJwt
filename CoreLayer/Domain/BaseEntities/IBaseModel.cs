using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntities
{
	public interface IBaseModel
	{
		public bool SoftDeleted { get; set; }
	}
}
