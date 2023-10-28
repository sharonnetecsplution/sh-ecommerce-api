using Lojinha.Application.Interfaces;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using Lojinha.Infra.IoC.Mediator;
using Lojinha.Infra.IoC.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/shoes")]
    public class ShoesController : Controller
    {
        private readonly IShoesService _IShoesService;
        private readonly IStockService _IStockService;
        public ShoesController(IShoesService ShoesService, IStockService stockService)
        {

            _IShoesService = ShoesService;
            _IStockService = stockService;

        }
        [HttpGet]
        public async Task<IEnumerable<ShoesList>> list()
        {

            IEnumerable<ShoesEntity> Shoes = await _IShoesService.GetAllLisAsync();
            return ShoesOutput.listShoes(Shoes);
        }


        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(ShoesInput ShoesInput)
        {
            if (ShoesInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto acessorio não pode ser nulo" });
            }

            var ShoesMediator = new ShoesMediator();
            try
            {
                IEnumerable<ShoesEntity> acessories = await _IShoesService.GetAllLisAsync();
                ShoesEntity ShoesEntity = ShoesMediator.ConvertInputInEntity(ShoesInput);
                var shoes = _IShoesService.Add(ShoesEntity);
                return new OkObjectResult(new Sucess { message = "Produto excluido com sucesso", result = ShoesOutput.EditShoes(shoes) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(ShoesModal ShoesModel)
        {
            if (ShoesModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Informações do produto não pode ser nulo" });
            }

            var ShoesMediator = new ShoesMediator();

            try
            {

                ShoesEntity ShoesEntity = ShoesMediator.ConvertModelInEntity(ShoesModel);
             
                    
                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = ShoesOutput.EditShoes( _IShoesService.Remove(ShoesEntity) )});
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(ShoesModal ShoesModel)
        {
            if (ShoesModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var categoryMediator = new ShoesMediator();
            try
            {
                ShoesEntity ShoesEntity = categoryMediator.ConvertModelInEntity(ShoesModel);
                var result = ShoesOutput.EditShoes(_IShoesService.Update(ShoesEntity).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
