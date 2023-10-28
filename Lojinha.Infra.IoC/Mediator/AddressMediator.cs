using Lojinha.Domain;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Mediator
{
    public class AddressMediator
    {
        public AddressEntity _AddressEntity { get; set; }
        public AddressMediator()
        {
            _AddressEntity = new AddressEntity();

        }

        public AddressEntity ConvertModelInEntity(AddressModel address)
        {
  
            _AddressEntity.Id = address.Id;
            _AddressEntity.Street = address.Street;
            _AddressEntity.Number = address.Number;
            _AddressEntity.Postal_code = address.Postal_code;
            _AddressEntity.District = address.District;
            _AddressEntity.State = address.State;
            _AddressEntity.County = address.County;

            return _AddressEntity;
        }

        public AddressEntity ConvertInputInEntity(AddressInput address)
        {


            _AddressEntity.Street = address.Street;
            _AddressEntity.Number = address.Number;
            _AddressEntity.Postal_code = address.Postal_code;
            _AddressEntity.District = address.District;
            _AddressEntity.State = address.State;
            _AddressEntity.County = address.County;



            return _AddressEntity;
        }
    }
}
