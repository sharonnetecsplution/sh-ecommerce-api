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
    [Route("api/v1/cart_itens")]
    public class CartItemController : Controller
    {
        private readonly ICartItemService _ICartItemService;
        private readonly IStockService _IStockService;
        public CartItemController(ICartItemService CartItemService, IStockService stockService)
        {

            _ICartItemService = CartItemService;
            _IStockService = stockService;

        }
        [HttpGet]
        public async Task<IEnumerable<CartItemlist>> list()
        {

            IEnumerable<CartItemEntity> CartItem = await _ICartItemService.GetAllLisAsync();
            return CartItemOutput.ListCartItem(CartItem);
        }


        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(CartItemInput CartItemInput)
        {
            if (CartItemInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto acessorio não pode ser nulo" });
            }

            var CartItemMediator = new CartItemMediator();
            try
            {
                IEnumerable<CartItemEntity> acessories = await _ICartItemService.GetAllLisAsync();
                CartItemEntity CartItemEntity = CartItemMediator.ConvertInputInEntity(CartItemInput);

                return new OkObjectResult(new Sucess { message = "Produto excluido com sucesso", result = CartItemOutput.EditCartItem(_ICartItemService.Add(CartItemEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(CartItemModel CartItemModel)
        {
            if (CartItemModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Informações do produto não pode ser nulo" });
            }

            var CartItemMediator = new CartItemMediator();

            try
            {

                CartItemEntity CartItemEntity = CartItemMediator.ConvertModelInEntity(CartItemModel);
              
                return new OkObjectResult(new Sucess { message = "carrinho excluido com sucesso", result = CartItemOutput.EditCartItem(_ICartItemService.Remove(CartItemEntity))});

                
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CartItemModel CartItemModel)
        {
            if (CartItemModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var categoryMediator = new CartItemMediator();
            try
            {
                CartItemEntity CartItemEntity = categoryMediator.ConvertModelInEntity(CartItemModel);
                var result = CartItemOutput.EditCartItem(_ICartItemService.Update(CartItemEntity).Result);

                return new OkObjectResult(new Sucess { message = "item do carrinho atualizado com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
