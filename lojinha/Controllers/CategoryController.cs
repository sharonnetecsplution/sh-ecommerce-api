using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Outputs;
using Lojinha.Infra.Ioc;
using Microsoft.AspNetCore.Mvc;
using Lojinha.Infra.IoC.Mediator;
using Microsoft.AspNetCore.Authorization;
using Lojinha.Infra.IoC.Inputs;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/categories")]
   
    public class CategoryController : Controller
    {
        private readonly ICategoryService _ICategoryService;
        private readonly ICategory_productService _ICategoryProductService;
        public CategoryController( ICategoryService categoryService, ICategory_productService categoryProductService)
        {
 
            _ICategoryService = categoryService;
            _ICategoryProductService = categoryProductService;

        }
        [HttpGet]
        public async Task<IEnumerable<CategoryList>> list()
        {
 
                IEnumerable<CategoryEntity> categories = await _ICategoryService.GetAllLisAsync();
                return CatergoryOutput.CategoryList(categories);
        }

        [HttpGet("{id}")]
        public async Task<CategoryList> CategoryId(int id)
        {

            CategoryEntity categories =  _ICategoryService.Get(id);
            return CatergoryOutput.CategoryId(categories);
        }
        [HttpPost("cadastro")]
    
        public async Task<IActionResult> Create(CategoryInput categoryInput)
        {
            if (categoryInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto não pode ser nulo" });
            }

            var categoryMediator = new CategoryMediator();
            try
            {
                IEnumerable<CategoryEntity> categories = await _ICategoryService.GetAllLisAsync();
                CategoryEntity categoryEntity = categoryMediator.CategoryConvertInputInEntity(categoryInput);
                if (categories.Any())
                {
                    bool categoryAny = categories.Any(c => c.Name == categoryEntity.Name);
                    if (categoryAny)
                    {
                        return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Categoria já cadastrada no sistema" });
                    }

                }
                
                return new OkObjectResult(CatergoryOutput.CadastroResult(_ICategoryService.Add(categoryEntity)));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto não pode ser nulo" });
            }

            var categoryMediator = new CategoryMediator();
            
            try
            {
               
                CategoryEntity categoryEntity = categoryMediator.CategoryConvertModelInEntity(categoryModel);
                IEnumerable<Category_productEntity> catPreoduct = _ICategoryProductService.CategoryGetById(categoryEntity.Id);    
                if(catPreoduct.Any())
                {
                    

                    _ICategoryProductService.RemoveRange(catPreoduct.Where(c => c.CategoryId == categoryEntity.Id).ToList());


                }

                var catName = _ICategoryService.GetAll().ToList().Where(c => c.Name == categoryEntity.Name ).ToList();
                //var CategoryDelete = _ICategoryService.RemoveRange(catName);
                var CategoryDelete = _ICategoryService.Remove(categoryEntity);

                return new OkObjectResult(new Error {  message = "Categoria excluido com sucesso" });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }


        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CategoryModel categoryModel)
        {
            if (categoryModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Produto não pode ser nulo" });
            }

            var categoryMediator = new CategoryMediator();
            try
            {
                CategoryEntity categoryEntity = categoryMediator.CategoryConvertModelInEntity(categoryModel);
         
                return new OkObjectResult(CatergoryOutput.CadastroResult(_ICategoryService.Update(categoryEntity).Result));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
