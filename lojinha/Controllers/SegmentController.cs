using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Outputs;
using Lojinha.Infra.Ioc;
using Microsoft.AspNetCore.Mvc;
using Lojinha.Infra.IoC.Mediator;
using Microsoft.AspNetCore.Authorization;
using Lojinha.Domain.Entities;
using Lojinha.Infra.IoC.Inputs;

namespace Lojinha.Api.Controllers
{

    [ApiController]
    [Route("api/v1/segments")]
  
    public class SegmentController : Controller
    {
        private readonly ISegmentService _ISegmentService;
        public SegmentController( ISegmentService segment)
        {

            _ISegmentService = segment;

        }

        [HttpGet]
        public async Task<IActionResult> list()
        {
            try
            {
                return new OkObjectResult(SegmentOutput.ListSegment(_ISegmentService.GetAll().ToList()));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error
                {
                    code = BadRequest().StatusCode, message = ex.Message.ToString()
                });

            }
            

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> list(int id)
        {
            try
            {
                var valor = _ISegmentService.Get(id);
                if (valor == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O segmento não existe na base de dados" });
                }
                return new OkObjectResult(SegmentOutput.EditSegment(_ISegmentService.Get(id)));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error
                {
                    code = BadRequest().StatusCode,
                    message = ex.Message.ToString()
                });

            }


        }
        [HttpPost("cadastro")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(SegmentInput segment)
        {

            if (segment == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O segmento não pode estar nulo" });
            }

            var segmentMediator = new SegmentMediator();
            try
            {
                SegmentEntity segmentEntity = segmentMediator.ConvertInputInEntity(segment);
                return new OkObjectResult(SegmentOutput.EditSegment(_ISegmentService.Add(segmentEntity)));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }

        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(SegmentModel SegmentModel)
        {
            if (SegmentModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O segmento não pode ser nulo" });
            }

            var SegmentMediator = new SegmentMediator();

            try
            {

                SegmentEntity SegmentEntity = SegmentMediator.ConvertModelInEntity(SegmentModel);

                return new OkObjectResult(new Sucess { message = "O segmento foi excluido com sucesso", result = SegmentOutput.EditSegment( _ISegmentService.Remove(SegmentEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(SegmentModel SegmentModel)
        {
            if (SegmentModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O segmento  não pode ser nulo" });
            }

            var categoryMediator = new SegmentMediator();
            try
            {
                SegmentEntity SegmentEntity = categoryMediator.ConvertModelInEntity(SegmentModel);
                var result = SegmentOutput.EditSegment(_ISegmentService.Update(SegmentEntity).Result);

                return new OkObjectResult(new Sucess { message = "O  segmento atualizado com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
