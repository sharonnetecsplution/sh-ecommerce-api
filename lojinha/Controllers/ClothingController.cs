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
    [Route("api/v1/clothings")]
    public class ClothingController : Controller
    {
        private readonly IClothingService _IClothingService;

        public ClothingController(IClothingService ClothingService)
        {

            _IClothingService = ClothingService;


        }
        [HttpGet]
        public async Task<IEnumerable<ClothingList>> list()
        {

            IEnumerable<ClothingEntity> Clothing = await _IClothingService.GetAllLisAsync();
            return ClothingOutput.listClothing(Clothing);
        }


        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(ClothingInput ClothingInput)
        {
            if (ClothingInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto acessorio não pode ser nulo" });
            }

            var ClothingMediator = new ClothingMediator();
            try
            {
                IEnumerable<ClothingEntity> acessories = await _IClothingService.GetAllLisAsync();
                ClothingEntity clothingEntity = ClothingMediator.ConvertInputInEntity(ClothingInput);

                return new OkObjectResult(new Sucess { message = "Produto excluido com sucesso", result = ClothingOutput.EditClothing(_IClothingService.Add(clothingEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(ClothingModel ClothingModel)
        {
            if (ClothingModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Informações do produto não pode ser nulo" });
            }

            var ClothingMediator = new ClothingMediator();

            try
            {

                ClothingEntity ClothingEntity = ClothingMediator.ConvertModelInEntity(ClothingModel);


                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = ClothingOutput.EditClothing(_IClothingService.Remove(ClothingEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(ClothingModel ClothingModel)
        {
            if (ClothingModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var categoryMediator = new ClothingMediator();
            try
            {
                ClothingEntity ClothingEntity = categoryMediator.ConvertModelInEntity(ClothingModel);
                var result = ClothingOutput.EditClothing(_IClothingService.Update(ClothingEntity).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
