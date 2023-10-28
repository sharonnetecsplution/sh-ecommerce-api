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
    [Route("api/v1/stocks")]

    public class StockController : Controller
    {
        public IStockService _IStockService { get; set; }

        public StockController(IStockService stockService)
        {
            _IStockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> list()
        {
            try
            {
                return new OkObjectResult(StockOutput.ListStock(await _IStockService.GetAllLisAsync()));
            }catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "não existe stock"});
            }

            

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> StockId(int id)
        {
            try
            {
                return new OkObjectResult(StockOutput.ListStock(_IStockService.Get(id)));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message});
            }



        }


        [HttpPost("cadastro")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(StockInput stockInput)
        {

            if (stockInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto não pode ser nulo" });
            }

            var stockMediator = new StockMediator(); 
            try
            {
                StockEntity stockEntity = stockMediator.ConvertInputInEntity(stockInput);
                return new OkObjectResult(new Sucess { message ="stock salvo com sucesso", result = StockOutput.EditStock(_IStockService.Add(stockEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(StockModel stockModel)
        {
            if (stockModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Informações do produto não pode ser nulo" });
            }

            var stockMediator = new StockMediator();

            try
            {

                StockEntity stockEntity = stockMediator.ConvertModelInEntity(stockModel);
                var stock = _IStockService.Get(stockModel.Id);
                if (stock == null)
                {

                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O produto em stock não encontrado, na base de dados" });

                }
                _IStockService.Remove(stockEntity);
                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = StockOutput.EditStock(stock) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(StockModel stockModel)
        {
            if (stockModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var stockMediator = new StockMediator();
            try
            {
                StockEntity stockEntity = stockMediator.ConvertModelInEntity(stockModel);
                //StockEntity stock =_IStockService.Get(stockModel.Id);
                //if(stock == null)
                //{
                //    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O produto em stock não encontrado, na base de dados" });
                //}
                var result = StockOutput.EditStock(_IStockService.Update(stockEntity).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
