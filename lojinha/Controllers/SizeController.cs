using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using Lojinha.Infra.IoC.Mediator;
using Lojinha.Infra.IoC.Outputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/sizes")]

    public class SizeController : Controller
    {
        private readonly ISizeService _ISizeService;

        public SizeController(ISizeService sizeService)
        {
            _ISizeService = sizeService;
        }

        [HttpGet]
        public async Task<IActionResult> list()
        {

            return new OkObjectResult(_ISizeService.GetAll().ToList());

        }

        [HttpPost("cadastro")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(SizeInput sizeModel)
        {
            if (sizeModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto não pode ser nulo" });
            }

            var sizeMediator = new SizeMediator();
            try
            {
                SizeEntity sizeEntity = sizeMediator.ConvertInputInEntity(sizeModel);
                return new OkObjectResult(SizeOutput.EditSize(_ISizeService.Add(sizeEntity)));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(SizeModel SizeModel)
        {
            if (SizeModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Informações do produto não pode ser nulo" });
            }

            var SizeMediator = new SizeMediator();

            try
            {

                SizeEntity SizeEntity = SizeMediator.ConvertModelInEntity(SizeModel);
             
                  

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = SizeOutput.EditSize(_ISizeService.Remove(SizeEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(SizeModel SizeModel)
        {
            if (SizeModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var sizeMediator = new SizeMediator();
            try
            {
                SizeEntity SizeEntity = sizeMediator.ConvertModelInEntity(SizeModel);
                var result = SizeOutput.EditSize(_ISizeService.Update(SizeEntity).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
