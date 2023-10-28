using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Mediator
{
    public class ImageMediator
    {
        public ImageEntity _ImageProductEntity { get; set; }

        public ImageMediator()
        {
            _ImageProductEntity = new ImageEntity();

        }

        public ImageEntity ConvertModelInEntity(ImageModel imageProductModel)
        {

            _ImageProductEntity.Name = imageProductModel.Name;
            _ImageProductEntity.endpoint = imageProductModel.edpoint;
            _ImageProductEntity.Extensao = imageProductModel.extensao;


            return _ImageProductEntity;
        }
    }
}
