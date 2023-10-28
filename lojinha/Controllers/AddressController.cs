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
    [Route("api/v1/address")]
    public class AddressController : Controller
    {
        private readonly IAddressService _IAddressService;
        private readonly IStockService _IStockService;
        public AddressController(IAddressService AddressService, IStockService stockService)
        {

            _IAddressService = AddressService;
            _IStockService = stockService;

        }
        [HttpGet]
        public async Task<IEnumerable<Address>> list()
        {

            IEnumerable<AddressEntity> Address = await _IAddressService.GetAllLisAsync();
            return AddressOutput.listAddress(Address);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> AddressId(int id)
        {

            AddressEntity Address = _IAddressService.Get(id);
            if (Address == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Address não existe" });
            }
            try
            {

                return new OkObjectResult(AddressOutput.AddressId(Address));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }

        }



        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(AddressInput AddressInput)
        {
            if (AddressInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Address não pode ser nulo" });
            }

            var AddressMediator = new AddressMediator();
            try
            {
                IEnumerable<AddressEntity> acessories = await _IAddressService.GetAllLisAsync();
                AddressEntity AddressEntity = AddressMediator.ConvertInputInEntity(AddressInput);

                return new OkObjectResult(new Sucess { message = "Address excluido com sucesso", result = AddressOutput.EditAddress(_IAddressService.Add(AddressEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(AddressModel AddressModel)
        {
            if (AddressModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Address não pode ser nulo" });
            }

            var AddressMediator = new AddressMediator();

            try
            {
                var Address = _IAddressService.Get(AddressModel.Id);
                if (Address == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Address não existe na base de dados" });
                }

                var result = _IAddressService.Remove(Address);


                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = AddressOutput.EditAddress(result) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(AddressModel addressModel)
        {
            if (addressModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var addressMediator = new AddressMediator();
            try
            {

                AddressEntity address = _IAddressService.Get(addressModel.Id);
                    
                if (address == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Address não existe na base de dados" });
                }
                    address = addressMediator.ConvertModelInEntity(addressModel);
            var result = AddressOutput.EditAddress(_IAddressService.Update(address).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
