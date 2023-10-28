using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using Lojinha.Infra.IoC.Mediator;
using Lojinha.Infra.IoC.Outputs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/carts")]
    public class CartController : Controller
    {
        private readonly ICartService _ICartService;
        private readonly ICartItemService _ICart_itemService;





        public CartController(ICartService cartService, ICartItemService cart_item)
        {
            _ICartService = cartService;
            _ICart_itemService = cart_item;


        }
        [HttpGet]
        public IEnumerable<dynamic> list()
        {

            try
            {
                return CartOutput.listAllCart(_ICartService.CartAll());
            }
            catch (Exception ex)
            {
                dynamic erro = new Error { code = BadRequest().StatusCode, message = ex.Message.ToString() };
                 return erro;
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartId(int id)
        {
            CartEntity cart = _ICartService.CartById(id);
           if (cart == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Nenhum Produto adicionado no carrinho" });
            }

           return new OkObjectResult(cart);
        }
        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(CartInput cartInput)
        {
            if (cartInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Carrinho já existe" });
            }

            var cartMediator = new CartMediator();
            try
            {
                IEnumerable<CartEntity> acessories = await _ICartService.GetAllLisAsync();
                CartEntity cartEntity = cartMediator.ConvertInputInEntity(cartInput);

                return new OkObjectResult(new Sucess { message = "criado com sucesso", result = CartOutput.EditCart(_ICartService.Add(cartEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(CartModel cartModel)
        {
            if (cartModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Informações do produto não pode ser nulo" });
            }

            var cartMediator = new CartMediator();

            try
            {

                CartEntity cartEntity = cartMediator.ConvertModelInEntity(cartModel);
                

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = _ICartService.Remove(cartEntity) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CartModel cartModel)
        {
            if (cartModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var cartMediator = new CartMediator();
            try
            {
                CartEntity cartEntity = cartMediator.ConvertModelInEntity(cartModel);
                var result = CartOutput.EditCart(_ICartService.Update(cartEntity).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

    }
}
