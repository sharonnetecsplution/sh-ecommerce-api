using Lojinha.Application.Interfaces;
using Lojinha.Application.Services.Base;
using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces;
using Lojinha.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Services
{
    public class ImageProductService : BaseService<ImageEntity>, IImageService
    {
        private readonly IImageRepository _ImageRepository;
        public ImageProductService(IImageRepository repository) : base(repository)
        {
            _ImageRepository = repository;
        }
    }
}
