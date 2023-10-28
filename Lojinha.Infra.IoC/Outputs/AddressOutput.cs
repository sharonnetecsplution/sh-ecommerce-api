using Lojinha.Domain;
using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class AddressOutput
    {
        public static Address EditAddress(AddressEntity addressEntity)
        {
            return new Address { 
                id = addressEntity.Id,
                street = addressEntity.Street, 
                number = addressEntity.Number, 
                postal_code = addressEntity.Postal_code,
                district = addressEntity.District,
                state = addressEntity.State, county = addressEntity.County 
            };
        }

        public static IList<Address> listAddress(IEnumerable<AddressEntity> AddressEntity)
        {

            var element = (from c in AddressEntity
                           select new Address()
                           {
                               id = c.Id,
                               street = c.Street,
                               number = c.Number,
                               postal_code = c.Postal_code,
                               district = c.District,
                               state = c.State,
                               county = c.County

                           }).ToList();
            return element;
        }


        public static Address AddressId(AddressEntity AddressEntity)
        {

            var element =  new Address()
                           {
                               id = AddressEntity.Id,
                               street = AddressEntity.Street,
                               number = AddressEntity.Number,
                               postal_code = AddressEntity.Postal_code,
                               district = AddressEntity.District,
                               state = AddressEntity.State,
                               county = AddressEntity.County

                           };
            return element;
        }
    }
    public class Address
    {
        public int id { get; set; }
        public string street { get; set; }
        public string number { get; set; }
        public string postal_code { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string county { get; set; }
    }
}
