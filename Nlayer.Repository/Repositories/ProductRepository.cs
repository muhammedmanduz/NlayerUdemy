using Microsoft.EntityFrameworkCore;
using NlayerCore.Model;
using NlayerCore.Repositoies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) :base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            //eager loading
            return await _context.Products.Include(x=> x.Category).ToListAsync();

        }
    }
}
