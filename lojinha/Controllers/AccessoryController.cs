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
    [Route("api/v1/accessories")]
    public class AccessoryController : Controller
    {
        private readonly IAccessoryService _IAccessoryService;

        public AccessoryController(IAccessoryService AccessoryService)
        {

            _IAccessoryService = AccessoryService;


        }
        [HttpGet]
        public async Task<IEnumerable<AcessoryList>> list()
        {

            IEnumerable<AccessoryEntity> Accessory = await _IAccessoryService.GetAllLisAsync();
            return AccessoryOutput.listAccessory(Accessory);
        }


        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(AccessoryInput AccessoryInput)
        {
            if (AccessoryInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto acessorio não pode ser nulo" });
            }

            var AccessoryMediator = new AccessoryMediator();
            try
            {
                IEnumerable<AccessoryEntity> acessories = await _IAccessoryService.GetAllLisAsync();
                AccessoryEntity AccessoryEntity = AccessoryMediator.ConvertInputInEntity(AccessoryInput);
                 var acessory =_IAccessoryService.Add(AccessoryEntity);


                return new OkObjectResult(new Sucess { message = "Produto excluido com sucesso", result = AccessoryOutput.EditAccessory(acessory) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(AccessoryModel AccessoryModel)
        {
            if (AccessoryModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Informações do produto não pode ser nulo" });
            }

            var AccessoryMediator = new AccessoryMediator();

            try
            {

                AccessoryEntity AccessoryEntity = AccessoryMediator.ConvertModelInEntity(AccessoryModel);


                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = AccessoryOutput.EditAccessory(_IAccessoryService.Remove(AccessoryEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(AccessoryModel AccessoryModel)
        {
            if (AccessoryModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var categoryMediator = new AccessoryMediator();
            try
            {
                AccessoryEntity AccessoryEntity = categoryMediator.ConvertModelInEntity(AccessoryModel);
                var result = AccessoryOutput.EditAccessory(_IAccessoryService.Update(AccessoryEntity).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso" , result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
