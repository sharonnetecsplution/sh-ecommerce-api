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
    public class ShoesMediator
    {
        public ShoesEntity _ShoesEntity { get; set; }

        public ShoesMediator()
        {
            _ShoesEntity = new ShoesEntity();
        }

        public ShoesEntity ConvertInputInEntity(ShoesInput shoes)
        {

            _ShoesEntity.Model = shoes.Model;
            _ShoesEntity.Gender = shoes.Gender;
            _ShoesEntity.Brand = shoes.Brand;
            _ShoesEntity.Type_of_activity = shoes.Type_of_activity;
            _ShoesEntity.Origin = shoes.Origin;
            _ShoesEntity.Technology = shoes.Technology;
            _ShoesEntity.Weight = shoes.Weight;
            _ShoesEntity.SegmentId = shoes.segmentId;



            return _ShoesEntity;
        }

        public ShoesEntity ConvertModelInEntity(ShoesModal shoes)
        {
            _ShoesEntity.Model = shoes.Model;
            _ShoesEntity.SegmentId = shoes.SegmentId;
            _ShoesEntity.Brand = shoes.Brand;
            _ShoesEntity.Type_of_activity = shoes.Type_of_activity;
            _ShoesEntity.Origin = shoes.Origin;
            _ShoesEntity.Technology = shoes.Technology;
            _ShoesEntity.Weight = shoes.Weight;

            return _ShoesEntity;
        }
    }
}
