using Lojinha.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Outputs
{
    public class CompanyOutput
    {
        public static CompanyCadastro EditCompany(CompanyEntity companyEntity)
        {
            return new CompanyCadastro { id = companyEntity.Id, name = companyEntity.Name, stores = companyEntity.Stores };
        }

        public static IList<CompanyList> listCompany(IEnumerable<CompanyEntity> companyEntity)
        {

            var element = (from c in companyEntity
                           select new CompanyList()
                           {
                               id = c.Id,
                               name = c.Name,
                               stores = c.Stores == null ? null : (from p in c.Stores select new
                               {
                                   adress = p.Address, segment = p.Segment , stocks = (from s in p.Stocks select new { s.Id, s.Product})
                               })

                           }).ToList();
            return element;
        }

        public static CompanyList CompanyId(CompanyEntity companyEntity)
        {

            var element = new CompanyList()
                           {
                               id = companyEntity.Id,
                               name = companyEntity.Name,
                               stores = companyEntity.Stores

                           };
            return element;
        }

    }

    public class CompanyCadastro
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<StoreEntity> stores { get; set; }
    }
    public class CompanyList
    {
        public int id { get; set; }
        public string name { get; set; }
        public dynamic? stores { get; set; }
    }
}
