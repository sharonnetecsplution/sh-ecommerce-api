using Lojinha.Domain;
using Lojinha.Domain.Interfaces;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.IoC.Mediator
{
    public class ColorMediator
    {
        public ColorEntity _ColorEntity { get; set; }

        public ColorMediator()
        {
            _ColorEntity = new ColorEntity();
            
        }

        public ColorEntity CategoryConvertInputInEntity(ColorInput colorInput)
        {

            _ColorEntity.Name = colorInput.Name;


            return _ColorEntity;
        }

        public ColorEntity CategoryConvertModelInEntity(ColorModel colorModel)
        {
            _ColorEntity.Id = colorModel.Id;
            _ColorEntity.Name = colorModel.Name;


            return _ColorEntity;
        }
    }
}
