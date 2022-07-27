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

        //readonly static string blobconnection = "DefaultEndpointsProtocol=https;AccountName=kmfritechnicalreports;AccountKey=hS2i/Yg40Zg0e2SySXrImpc57m5m2OMo8ua2R1SeKgCBM8uR8ACaT0A/+ZAXuEiMsgdYpu4A+xfc+ASt2V0y6w==;EndpointSuffix=core.windows.net";

        public BlobServiceClient BlobServiceClient { get; }

        public async Task<UrlsModel> PdfUpload(IFormFile file)
        {
            /*if(file.ContentType == "application/pdf")
            {
                throw new InvalidDataException("Only Pdf files allowed");
            }*/


          
            try
            {
                var blobcontainer = _blobServiceClient.GetBlobContainerClient("reports");

                var blobclient = blobcontainer.GetBlobClient(file.FileName);

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
