using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Mediator
{
    public class StockMediator
    {
        public StockEntity _StockEntity { get; set; }
        public StockMediator()
        {
            _StockEntity =  new StockEntity();
        }

        public StockEntity ConvertInputInEntity(StockInput stock)
        {

            _StockEntity.ProductId = stock.ProductId;
            _StockEntity.StoreId = stock.StoreId;
            _StockEntity.AmountTotal = stock.Amount;


            return _StockEntity;
        }

        public StockEntity ConvertModelInEntity(StockModel stock)
        {
            _StockEntity.Id = stock.Id;
            _StockEntity.ProductId = stock.ProductId;
            _StockEntity.StoreId=stock.StoreId;
  
            _StockEntity.AmountTotal = stock.Amount;


            return _StockEntity;
        }
    }
}
