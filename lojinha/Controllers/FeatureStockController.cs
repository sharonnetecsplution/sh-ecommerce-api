using Lojinha.Application.Interfaces;
using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using Lojinha.Infra.IoC.Mediator;
using Lojinha.Infra.IoC.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/feature_stock")]
    public class FeatureStockController: Controller
    {
        private readonly IFeatureStockService _IFeatureStockService;
        private readonly IStockService _IStockService;
        public FeatureStockController(IFeatureStockService FeatureStockService, IStockService stockService)
        {

            _IFeatureStockService = FeatureStockService;
            _IStockService = stockService;

        }
        [HttpGet]
        public async Task<IEnumerable<FeatureStockList>> list()
        {

            IEnumerable<FeatureStockEntity> FeatureStock = await _IFeatureStockService.GetAllLisAsync();
            return  FeatureStockOutput.listFeatureStock(FeatureStock);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FeatureStockId(int id)
        {

            FeatureStockEntity FeatureStock = _IFeatureStockService.Get(id);
            if (FeatureStock == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "FeatureStock não existe" });
            }
            try
            {

                return new OkObjectResult(FeatureStockOutput.FeatureStockId(FeatureStock));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }

        }



        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(FeatureStockInput FeatureStockInput)
        {
            if (FeatureStockInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O FeatureStock não pode ser nulo" });
            }

            var FeatureStockMediator = new FeatureStockMediator();
            try
            {
                IEnumerable<FeatureStockEntity> acessories = await _IFeatureStockService.GetAllLisAsync();
                FeatureStockEntity FeatureStockEntity = FeatureStockMediator.ConvertInputInEntity(FeatureStockInput);

                return new OkObjectResult(new Sucess { message = "FeatureStock excluido com sucesso", result = FeatureStockOutput.EditFeatureStock(_IFeatureStockService.Add(FeatureStockEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(FeatureStockModel FeatureStockModel)
        {
            if (FeatureStockModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O FeatureStock não pode ser nulo" });
            }

            var FeatureStockMediator = new FeatureStockMediator();

            try
            {
                var FeatureStock = _IFeatureStockService.Get(FeatureStockModel.Id);
                if (FeatureStock == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "FeatureStock não existe na base de dados" });
                }

                var result = _IFeatureStockService.Remove(FeatureStock);


                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = FeatureStockOutput.EditFeatureStock(result) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(FeatureStockModel FeatureStockModel)
        {
            if (FeatureStockModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var FeatureStockMediator = new FeatureStockMediator();
            try
            {

                FeatureStockEntity FeatureStock = _IFeatureStockService.Get(FeatureStockModel.Id);

                if (FeatureStock == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "FeatureStock não existe na base de dados" });
                }
                FeatureStock = FeatureStockMediator.ConvertModelInEntity(FeatureStockModel);
                var result = FeatureStockOutput.EditFeatureStock(_IFeatureStockService.Update(FeatureStock).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
