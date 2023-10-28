using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Inputs;
using Lojinha.Infra.IoC.Mediator;
using Lojinha.Infra.IoC.Outputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/colories")]
   
    public class ColorController : Controller
    {
        private readonly IColorService _IColorService;
        public ColorController(IColorService colorService)
        {

            _IColorService = colorService;

        }

        [HttpGet]
        public async Task<IActionResult> list()
        {
            try
            {
                return new OkObjectResult(ColorOutput.listAllColor(_IColorService.GetAll().ToList()));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message.ToString() });
            }
            

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> listId(int id)
        {
            try
            {
                dynamic val = _IColorService.Get(id);
                if (val == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "cor não encotrado na base de dados" });
                }
                return new OkObjectResult(ColorOutput.EditColor( _IColorService.Get(id)));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message.ToString() });
            }


        }

        [HttpPost("cadastro")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ColorInput colorModel)
        {
            if (colorModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "A cor não pode ser nula" });
            }

            var colorMediator = new ColorMediator();
            try
            {
                ColorEntity colorEntity = colorMediator.CategoryConvertInputInEntity(colorModel);
                return new OkObjectResult(ColorOutput.EditColor(_IColorService.Add(colorEntity)));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message.ToString() });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(ColorModel colorModel)
        {
            if (colorModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "A cor  não pode ser nula" });
            }

            var colorMediator = new ColorMediator();

            try
            {
                ColorEntity result = _IColorService.Get(colorModel.Id);

                if (result == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "A Cor Não Exite na base de dados" });
                }
              

                return new OkObjectResult(new Sucess { message = "Cor excluido com sucesso", result = ColorOutput.EditColor(_IColorService.Remove(result)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message.ToString() });
            }
        }


        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(ColorModel colorModel)
        {
            if (colorModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "A cor não pode ser nula" });
            }
            var colorMediator = new ColorMediator();
            try
            {
               

                ColorEntity result = _IColorService.Get(colorModel.Id);
                result.Name = colorModel.Name;

                if (result == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "A Cor Não Exite na base de dados" });
                }

                return new OkObjectResult(new Sucess { message = "Cor atualizado com sucesso", result = ColorOutput.EditColor(_IColorService.Update(result).Result)});
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message.ToString() });
            }
        }
    }
}
