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
    public class FeatureStockMediator
    {
        public FeatureStockEntity _FeatureStockEntity { get; set; }

        public FeatureStockMediator()
        {
            _FeatureStockEntity = new FeatureStockEntity();
        }

        public FeatureStockEntity ConvertInputInEntity(FeatureStockInput f)
        {
            _FeatureStockEntity.ColorId = f.ColorId;
            _FeatureStockEntity.StockId = f.StockId;
            _FeatureStockEntity.SizeId = f.SizeId;
            _FeatureStockEntity.ImageId = f.ImageId;
            _FeatureStockEntity.amount = f.amount;
     

            return _FeatureStockEntity;
        }

        public FeatureStockEntity ConvertModelInEntity(FeatureStockModel f)
        {
            _FeatureStockEntity.Id = f.Id;
            _FeatureStockEntity.ColorId = f.ColorId;
            _FeatureStockEntity.StockId = f.StockId;
            _FeatureStockEntity.SizeId = f.SizeId;
            _FeatureStockEntity.ImageId = f.ImageId;
            _FeatureStockEntity.amount = f.amount;

            return _FeatureStockEntity;
        }
    }
}
