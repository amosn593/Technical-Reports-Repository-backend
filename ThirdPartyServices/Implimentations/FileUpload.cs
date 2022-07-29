using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureBlobStorage.Interfaces;
using AzureBlobStorage.Models;
using Microsoft.AspNetCore.Http;

namespace AzureBlobStorage.Implimentations
{
    public class FileUpload : IFileUpload
    {
        private readonly BlobServiceClient  _blobServiceClient;
        public FileUpload(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        
        public BlobServiceClient BlobServiceClient { get; }

        public async Task<UrlsModel> PdfUpload(IFormFile file)
        {
            var ConteType = new String[] { "application/pdf" };

            if(!ConteType.Contains(file.ContentType))
            {
                throw new InvalidDataException("Only Pdf files allowed");
            }
          
            try
            {
                // get filename base and extension
                //var fileBase = Path.GetFileNameWithoutExtension(file.FileName);
               // var ext = Path.GetExtension(file.FileName);

               //var newfileBase = fileBase.Replace(' ', '-').ToLower();

               // var newfile = Path.Combine(newfileBase, ext);


                var blobcontainer = _blobServiceClient.GetBlobContainerClient("reports");

                var blobclient = blobcontainer.GetBlobClient(file.FileName.Replace(' ', '-').ToLower());

                 await blobclient.UploadAsync(file.OpenReadStream(),
                    new BlobHttpHeaders {ContentType = file.ContentType});

                var filepath = blobclient.Uri.ToString();

                return new UrlsModel(filepath);
            }
            catch (Exception)
            {
                throw new Exception("Some went wrong while upload file to Azure Blob Storage");
            }
            
        }
    }
}
