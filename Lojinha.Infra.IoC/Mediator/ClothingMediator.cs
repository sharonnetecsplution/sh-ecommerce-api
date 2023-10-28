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
    public class ClothingMediator
    {
        public ClothingEntity _ClothingEntity { get; set; }

        public ClothingMediator()
        {
            _ClothingEntity = new ClothingEntity();
        }

        public ClothingEntity ConvertInputInEntity(ClothingInput clothingInput)
        {

            _ClothingEntity.Brand = clothingInput.Brand;
            _ClothingEntity.Made_by= clothingInput.Made_by;
            _ClothingEntity.Composition = clothingInput.Composition;
            _ClothingEntity.Origin = clothingInput.Origin;
            _ClothingEntity.SegmentId = clothingInput.SegmentId;


            return _ClothingEntity;
        }

        public ClothingEntity ConvertModelInEntity(ClothingModel clothingModel)
        {
            _ClothingEntity.Id = clothingModel.Id;
            _ClothingEntity.Brand = clothingModel.Brand;
            _ClothingEntity.Made_by = clothingModel.Made_by;
            _ClothingEntity.Composition = clothingModel.Composition;
            _ClothingEntity.Origin = clothingModel.Origin;
            _ClothingEntity.SegmentId = clothingModel.SegmentId;


            return _ClothingEntity;
        }
    }
}
