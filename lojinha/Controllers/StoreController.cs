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
    [Route("api/v1/stores")]
    public class StoreController : Controller
    {
        private readonly IStoreService _IStoreService;
        private readonly IStockService _IStockService;
        public StoreController(IStoreService StoreService, IStockService stockService)
        {

            _IStoreService = StoreService;
            _IStockService = stockService;

        }
        [HttpGet]
        public async Task<IEnumerable<StoreList>> list()
        {

            IEnumerable<StoreEntity> Store = await _IStoreService.GetAllLisAsync();
            return StoreOutput.listStore(Store);
        }


        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(StoreInput StoreInput)
        {
            if (StoreInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "A loja não pode ser nulo" });
            }

            var StoreMediator = new StoreMediator();
            try
            {
                IEnumerable<StoreEntity> acessories = await _IStoreService.GetAllLisAsync();
                StoreEntity StoreEntity = StoreMediator.ConvertInputInEntity(StoreInput);
                var store = _IStoreService.Add(StoreEntity);

                return new OkObjectResult(new Sucess { message = "Loja excluido com sucesso", result = StoreOutput.EditStore(store) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(StoreModal storeModel)
        {
            if (storeModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "A informações da loja não pode ser nulo" });
            }

            var StoreMediator = new StoreMediator();

            try
            {

                StoreEntity storeEntity = StoreMediator.ConvertModelInEntity(storeModel);
                 var store =_IStoreService.Get(storeModel.Id);
                if(store == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Loja não existe na base de dados" });
                }
           

                return new OkObjectResult(new Sucess { message = "Informações do Loja excluido com sucesso", result = StoreOutput.EditStore(_IStoreService.Remove(store)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(StoreModal StoreModel)
        {
            if (StoreModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var categoryMediator = new StoreMediator();
            try
            {
                StoreEntity StoreEntity = categoryMediator.ConvertModelInEntity(StoreModel);
                var result = StoreOutput.EditStore(_IStoreService.Update(StoreEntity).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
  
}
