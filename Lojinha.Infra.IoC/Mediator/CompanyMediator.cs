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
   public class CompanyMediator
    {
        public CompanyEntity _CompanyEntity { get; set; }

        public CompanyMediator()
        {
            _CompanyEntity = new CompanyEntity();
        }

        public CompanyEntity ConvertInputInEntity(CompanyInput companyInput)
        {
            _CompanyEntity.Name = companyInput.Name;
           


            return _CompanyEntity;
        }

        public CompanyEntity ConvertModelInEntity(CompanyModel companyModel)
        {
            _CompanyEntity.Id = companyModel.Id;
            _CompanyEntity.Name = companyModel.Name;



            return _CompanyEntity;
        }
    }
}
