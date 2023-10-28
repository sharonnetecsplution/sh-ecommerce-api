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
    [Route("api/v1/companies")]


    public class CompanyController : Controller
    {
        private readonly ICompanyService _ICompanyService;
        private readonly IStockService _IStockService;
        public CompanyController(ICompanyService CompanyService, IStockService stockService)
        {

            _ICompanyService = CompanyService;
            _IStockService = stockService;

        }
        [HttpGet]
        public async Task<IEnumerable<CompanyList>> list()
        {

            IEnumerable<CompanyEntity> Company = await _ICompanyService.GetAllLisAsync();
            return CompanyOutput.listCompany(Company);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CompanyId(int id)
        {

            CompanyEntity company =  _ICompanyService.Get(id);
            if (company == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "company não existe" });
            }
            try
            {
              
                return new OkObjectResult(CompanyOutput.CompanyId(company));
            }catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
            
        }



        [HttpPost("cadastro")]

        public async Task<IActionResult> Create(CompanyInput CompanyInput)
        {
            if (CompanyInput == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Company não pode ser nulo" });
            }

            var CompanyMediator = new CompanyMediator();
            try
            {
                IEnumerable<CompanyEntity> acessories = await _ICompanyService.GetAllLisAsync();
                CompanyEntity CompanyEntity = CompanyMediator.ConvertInputInEntity(CompanyInput);

                return new OkObjectResult(new Sucess { message = "Company excluido com sucesso", result = CompanyOutput.EditCompany(_ICompanyService.Add(CompanyEntity)) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(CompanyModel CompanyModel)
        {
            if (CompanyModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "O Company não pode ser nulo" });
            }

            var CompanyMediator = new CompanyMediator();

            try
            {
                var company = _ICompanyService.Get(CompanyModel.Id);
                if (company == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Company não existe na base de dados" });
                }

                var result = _ICompanyService.Remove(company);


                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = CompanyOutput.EditCompany(result) });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }



        [HttpPatch("atualizar")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CompanyModel CompanyModel)
        {
            if (CompanyModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Informações do produto não pode ser nulo" });
            }

            var categoryMediator = new CompanyMediator();
            try
            {

                var company =_ICompanyService.Get(CompanyModel.Id);
                if(company == null)
                {
                    return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Company não existe na base de dados" });
                }
                var result = CompanyOutput.EditCompany(_ICompanyService.Update(company).Result);

                return new OkObjectResult(new Sucess { message = "Informações do produto excluido com sucesso", result = result });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = ex.Message });
            }
        }
    }
}
