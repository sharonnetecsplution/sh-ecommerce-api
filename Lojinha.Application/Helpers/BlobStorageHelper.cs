using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Lojinha.Application.Helpers.Interfaces;
using Lojinha.Application.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lojinha.Application.Helpers
{
    public class BlobStorageHelper : IBlobStorageHelper
    {
        public async Task<List<string>> GetAllDocuments(string connectionString, string containerName)
        {
            var container = BlobExtensions.GetContainer(connectionString, containerName);

            if (!await container.ExistsAsync())
            {
                return new List<string>();
            }

            List<string> blobs = new();

            await foreach (BlobItem blobItem in container.GetBlobsAsync())
            {
                blobs.Add(blobItem.Name);
            }
            return blobs;
        }

        public async Task<UpdateBlobStorageModel> UploadDocument(string connectionString, string name,string company,string extensao, string base64Image)
        {
            string date = DateTime.Now.Day.ToString()+"-"+DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString()+"-"+DateTime.Now.Hour.ToString()+"-"+DateTime.Now.Minute.ToString() + "-"+DateTime.Now.Millisecond.ToString();
            var fileName = name+"-"+date.ToString()+ "." + extensao;
            var container = BlobExtensions.GetContainer(connectionString, company);
            string data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");
            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);
            // Define o BLOB no qual a imagem será armazenada
            if (!await container.ExistsAsync())
            {
               
                BlobServiceClient blobServiceClient = new(connectionString);
                await blobServiceClient.CreateBlobContainerAsync(company);
                container = blobServiceClient.GetBlobContainerClient(company);
            }

            var bobclient = container.GetBlobClient(fileName);

            using (var stream = new MemoryStream(imageBytes))
            {
                await bobclient.UploadAsync(stream, new BlobHttpHeaders { ContentType = $"application/{extensao}" });

            }

            return new UpdateBlobStorageModel { fileName = fileName, endpoint = bobclient.Uri.AbsoluteUri, extensao = extensao };

        }

  
        public async Task<Stream> GetDocument(string connectionString, string containerName, string fileName)
        {
            var container = BlobExtensions.GetContainer(connectionString, containerName);
            if (await container.ExistsAsync())
            {
                var blobClient = container.GetBlobClient(fileName);
                if (blobClient.Exists())
                {
                    var content = await blobClient.DownloadStreamingAsync();
                    return content.Value.Content;
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            else
            {
                throw new FileNotFoundException();
            }

        }

        public async Task<bool> DeleteDocument(string connectionString, string containerName, string fileName)
        {
            var container = BlobExtensions.GetContainer(connectionString, containerName);
            if (!await container.ExistsAsync())
            {
                return false;
            }

            var blobClient = container.GetBlobClient(fileName);

            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteIfExistsAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static class BlobExtensions
    {
        public static BlobContainerClient GetContainer(string connectionString, string containerName)
        {
            BlobServiceClient blobServiceClient = new(connectionString);
            return blobServiceClient.GetBlobContainerClient(containerName);
        }
    }
}
