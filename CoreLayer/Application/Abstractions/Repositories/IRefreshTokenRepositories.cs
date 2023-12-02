using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Repositories.IBaseRepositories;
using Domain.AuthEntities;

namespace Application.Abstractions.Repositories
{
    public interface IRefreshTokenRepositories:IBaseRepository<RefreshToken,Guid>
    {
    }
}
