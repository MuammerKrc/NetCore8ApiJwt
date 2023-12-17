using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Repositories.BaseRepositories;
using Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class ProductRepositories : BaseRepository<Product, Guid>, IProductRepositories
	{
		public ProductRepositories(AppDbContext context) : base(context)
		{

		}
	}
}
