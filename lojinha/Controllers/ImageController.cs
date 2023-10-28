using Lojinha.Application.Helpers;
using Lojinha.Application.Helpers.Models;
using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain.Entities;
using Lojinha.Infra.Data.Models;
using Lojinha.Infra.IoC.Mediator;
using Lojinha.Infra.IoC.Outputs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Lojinha.Api.Controllers
{
    [ApiController]
    [Route("api/v1/images")]

    public class ImageController : Controller
    {

        private readonly IImageService _ImageService;
        private  IConfiguration _IConfiguration;
        public ImageController(IImageService imageService, IConfiguration configuration)
        {
            _ImageService = imageService;
            _IConfiguration = configuration;
           

        }
        [HttpGet]
       
        public async Task<IActionResult> list()
        {
            return  new OkObjectResult( _ImageService.GetAll());
        }
        [HttpPost("cadastro")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ImageModel imageModel)
        {

            if (imageModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Imagem do produto não pode ser nulo" });
            }
            BlobStorageHelper blobStorage = new BlobStorageHelper();
            dynamic blobConnection = _IConfiguration.GetSection("BlobStorage")["ConnectionString"];
            UpdateBlobStorageModel updateBlob = await blobStorage.UploadDocument(blobConnection, imageModel.Name, imageModel.company,imageModel.extensao, imageModel.image64);
            
            imageModel.extensao = updateBlob.extensao;
            imageModel.edpoint = updateBlob.endpoint;
            var  imageProductMediator = new ImageMediator();
            var image = imageProductMediator.ConvertModelInEntity(imageModel);

            var result = _ImageService.Add(image);
             

            return new OkObjectResult(ImageOutput.CadastroResult(result));
        }

        [HttpDelete("excluir")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(ImageModel imageModel)
        {

            if (imageModel == null)
            {
                return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Imagem do produto não pode ser nulo" });
            }
            BlobStorageHelper blobStorage = new BlobStorageHelper();
            dynamic blobConnection = _IConfiguration.GetSection("BlobStorage")["ConnectionString"];
            bool updateBlob = await blobStorage.DeleteDocument(blobConnection, imageModel.company, imageModel.Name);

            if(updateBlob)
            {
                return new OkObjectResult(new { messagem = "Image deletada com sucesso" });

            }

            return new OkObjectResult(new Error { code = BadRequest().StatusCode, message = "Imagem do produto não existe" });


        }




    }
}
