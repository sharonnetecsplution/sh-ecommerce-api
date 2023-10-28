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
    public class SizeMediator
    {
        public SizeEntity _SizeEntity { get; set; }

        public SizeMediator()
        {
            _SizeEntity = new SizeEntity();

        }

        public SizeEntity ConvertInputInEntity(SizeInput SizeInput)
        {

            _SizeEntity.Name = SizeInput.Name;


            return _SizeEntity;
        }

        public SizeEntity ConvertModelInEntity(SizeModel SizeModel)
        {
            _SizeEntity.Id = SizeModel.Id;
            _SizeEntity.Name = SizeModel.Name;


            return _SizeEntity;
        }
    }
}
