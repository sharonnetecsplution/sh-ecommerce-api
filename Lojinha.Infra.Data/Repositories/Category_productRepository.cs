using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Interfaces
{
    public class Category_productRepository : BaseRepository<Category_productEntity>, ICategory_productRepository
    {
        public Category_productRepository(ApplicationDbContext context) : base(context)
        {
        }


        public IEnumerable<Category_productEntity> CategoryGetAll()
        {
            return DbSet.Include(s => s.Category).AsNoTracking();
        }
       
        public override IEnumerable<Category_productEntity> GetAll()
        {
            return DbSet.Include(s => s.Category).Include(p => p.Product).AsNoTracking();
        }

      
        public IEnumerable<Category_productEntity> CategoryGetById(int categoryId)
        {
            return DbSet.Include(c => c.Category).Where(c => c.CategoryId == categoryId).ToList();
        }

        public async Task<IEnumerable<Category_productEntity>> ProdutoGetById(int produtoId)
        {
            return  DbSet.Include(c => c.Category).Where(c => c.ProductId == produtoId).AsNoTracking();
        }
    }
}
