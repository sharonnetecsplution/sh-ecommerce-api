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
    public class StoreMediator
    {
        public StoreEntity _StoreEntity { get; set; }

        public StoreMediator()
        {
            _StoreEntity = new StoreEntity();
        }

        public StoreEntity ConvertInputInEntity(StoreInput store)
        {

            _StoreEntity.Name = store.Name;
            _StoreEntity.Description = store.Description;
            _StoreEntity.AddressId = store.AddressId;
            _StoreEntity.CompanyId = store.CompanyId;
            _StoreEntity.SegmentId = store.SegmentId;

            return _StoreEntity;
        }

        public StoreEntity ConvertModelInEntity(StoreModal store)
        {
            _StoreEntity.Id = store.Id;
            _StoreEntity.Name = store.Name;
            _StoreEntity.Description = store.Description;
            _StoreEntity.AddressId = store.AddressId;
            _StoreEntity.CompanyId = store.CompanyId;
            _StoreEntity.SegmentId = store.SegmentId;


            return _StoreEntity;
        }
    }
}
