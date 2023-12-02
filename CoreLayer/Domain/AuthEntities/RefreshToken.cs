using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.BaseEntities;
using Domain.IdentityEntities;

namespace Domain.AuthEntities
{
	public class RefreshToken : BaseModel<Guid>
	{
		public Guid? UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public AppUser? User { get; set; }
	}
}
