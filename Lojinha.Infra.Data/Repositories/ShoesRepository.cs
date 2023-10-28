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
    public class ShoesRepository : BaseRepository<ShoesEntity>, IShoesRepository
    {
        IAddressRepository _addressRepository;
        public ShoesRepository(ApplicationDbContext context) : base(context)
        {
            _addressRepository = new AddressRepository(context);
        }

        public override Task<List<ShoesEntity>> GetAllLisAsync()
        {
            var result = DbSet.Include(c => c.Segment).AsNoTracking().ToListAsync();





            return result;
        }
    }

}
