using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Mediator
{
    public class AccessoryMediator
    {
        public AccessoryEntity _AccessoryEntity { get; set; }

        public AccessoryMediator()
        {
            _AccessoryEntity = new AccessoryEntity();
        }

        public AccessoryEntity ConvertInputInEntity(AccessoryInput accessorioInput)
        {

            _AccessoryEntity.Brand = accessorioInput.Brand;
            _AccessoryEntity.Embalagem = accessorioInput.Embalagem;
            _AccessoryEntity.SegmentId = accessorioInput.segmentId;
            _AccessoryEntity.Conservacao = accessorioInput.Conservacao;
            _AccessoryEntity.Made_by = accessorioInput.Made_by;


            return _AccessoryEntity;
        }

        public AccessoryEntity ConvertModelInEntity(AccessoryModel accessorioModel)
        {
            _AccessoryEntity.SegmentId = accessorioModel.segmentId;
            _AccessoryEntity.Brand = accessorioModel.Brand;
            _AccessoryEntity.Conservacao = accessorioModel.Conservacao;
            _AccessoryEntity.Embalagem = accessorioModel.Embalagem;
            _AccessoryEntity.Made_by = accessorioModel.Made_by;


            return _AccessoryEntity;
        }
    }
}
