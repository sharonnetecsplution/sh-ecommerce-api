using Lojinha.Application.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Application.Helpers.Interfaces
{
    public interface IBlobStorageHelper
    {
        public Task<List<string>> GetAllDocuments(string connectionString, string containerName);
        Task<UpdateBlobStorageModel> UploadDocument(string connectionString, string name, string company, string extensao, string base64Image);
        Task<Stream> GetDocument(string connectionString, string containerName, string fileName);
        Task<bool> DeleteDocument(string connectionString, string containerName, string fileName);
    }
}
