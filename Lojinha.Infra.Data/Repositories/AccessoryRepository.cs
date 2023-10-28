using Lojinha.Domain;
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
using static Amazon.S3.Util.S3EventNotification;

namespace Lojinha.Infra.Data.Repositories
{
    public class AccessoryRepository : BaseRepository<AccessoryEntity>, IAccessoryRepository
    {
        public AccessoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<AccessoryEntity> AccessoryGetById(int accessoryId)
        {
            return DbSet.Include(c => c.Segment).Where(c => c.Id ==  accessoryId).ToList();
        }

        public override Task<List<AccessoryEntity>> GetAllLisAsync()
        {
            var result = DbSet.Include(c => c.Segment).AsNoTracking().ToListAsync();

            return result;
        }
    }
}
