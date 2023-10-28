using Lojinha.Domain.Entities;
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
    public class ImageRepository : BaseRepository<ImageEntity>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext context) : base(context)
        {
        }
 
    }
}
