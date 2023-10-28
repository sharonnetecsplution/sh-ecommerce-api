using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces;
using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Data.Repositories
{
    public class ClothingRepository : BaseRepository<ClothingEntity>, IClothingRepository
    {
        public ClothingRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override Task<List<ClothingEntity>> GetAllLisAsync()
        {
            var result = DbSet.Include(c => c.Segment).AsNoTracking().ToListAsync();

            return result;
        }
    }
}
