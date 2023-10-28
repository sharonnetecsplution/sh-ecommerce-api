using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Domain.Interfaces
{
    public class ColorRepository : BaseRepository<ColorEntity>, IColorRepository
    {
        public ColorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
