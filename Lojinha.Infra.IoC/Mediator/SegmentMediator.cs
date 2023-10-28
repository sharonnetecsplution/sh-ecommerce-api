using Lojinha.Application.Services;
using Lojinha.Domain;
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
    public class SegmentMediator
    {
        public SegmentEntity _SegmentEntity { get; set; }

        public SegmentMediator()
        {
            _SegmentEntity = new SegmentEntity();
        }
        public SegmentEntity Cadastro(SegmentModel segment)
        {
            _SegmentEntity.Name = segment.Name;
            return _SegmentEntity;
        }

        public SegmentEntity ConvertInputInEntity(SegmentInput SegmentInput)
        {

            _SegmentEntity.Name= SegmentInput.Name;
            


            return _SegmentEntity;
        }

        public SegmentEntity ConvertModelInEntity(SegmentModel SegmentModel)
        {
            _SegmentEntity.Id = SegmentModel.Id;
            _SegmentEntity.Name = SegmentModel.Name;

            return _SegmentEntity;
        }
    }
}
