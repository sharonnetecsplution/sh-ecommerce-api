using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.Ioc;
using Lojinha.Infra.IoC.Inputs;
using Lojinha.Infra.IoC.Mediator;
using Lojinha.Infra.IoC.Outputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
   
    public class ProductController : ControllerBase
    {
        private readonly IProductService _IProductService;
        private readonly ISegmentService _ISegmentService;
        private readonly ICategoryService _ICategoryService;

        private readonly IStockService _IStockService;
        private readonly IImageService _ImageService;
        private readonly ICategory_productService _ICategory_productService;

        public ProductController(IProductService productsService, IImageService imageService, ICategoryService categoryService,  ICategory_productService category_productService, ISegmentService segmentService, IStockService stockService)
        {
            _IProductService = productsService;
            _ICategoryService = categoryService;
            _ImageService = imageService;
            _IStockService = stockService; 

            _ISegmentService = segmentService;
            _ICategory_productService = category_productService;

        }

        [HttpGet]
        public async Task<IActionResult> list()
        {
            IList<ProductEntity> prodList = new List<ProductEntity>();
            try
            {
                return new OkObjectResult(ProductOutput.ListProduct(_IProductService.GetAllLisAsync().Result));

            }
            catch (Exception)
            {

                throw;
            }

            

            return new OkObjectResult(ProductOutput.ListProduct(prodList));

        }

        [HttpPost("cadastro")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ProductInput product)
        {
            if (product == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto não pode ser nulo" });
            }

            
            var productMediator = new ProductMediator();

            try
            {
                          
                ProductEntity productEntity = productMediator.ConvertInputInEntity(product);
                var products = await _IProductService.AddAsync(productEntity);
                return new OkObjectResult(new Sucess { message="Produto cadastrado com sucesso", result = ProductOutput.EditProduct(products ) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
        [HttpPost("categories")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> registerCategoryProduct(Category_productModel categoryProductModel)
        {

            if (categoryProductModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Não foi enviado nenhum produto para ser adicionado" });
            }

            var categoryProductMediator = new Category_productMediator();
            try
            {
                Category_productEntity category_productEntity = categoryProductMediator.Cadastro(categoryProductModel);
                return new OkObjectResult(Category_productOutput.CadastroResult(_ICategory_productService.Add(category_productEntity)));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }



        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> selectProduct(int id)
        {
           
            try
            {

                ProductEntity product = _IProductService.Get(id);
                if(product == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Produto não encontrado" });
                }
 
                return new ObjectResult(ProductOutput.ProductResult(product));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code= BadRequest().StatusCode, message =  ex.Message });
            }

        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(ProductModel product)
        {
            var productMediator = new ProductMediator();
            try
            {
               
                ProductEntity productEntity = _IProductService.Get(product.Id);
                if (product == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Produto não encontrado" });
                }

                 var result =_IProductService.Remove(productEntity);
                return new ObjectResult(new Sucess { message = "Produto Excluido com sucesso", result = ProductOutput.ProductResult(result)});
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message.ToString() });
            }

        }

        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(ProductModel productModel)
        {
            if (productModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var categoryMediator = new ProductMediator();

            try
            {
                ProductEntity ProductEntity = categoryMediator.ConvertModelInEntity(productModel);
                var result = ProductOutput.EditProduct(_IProductService.Update(ProductEntity).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



    }
}
