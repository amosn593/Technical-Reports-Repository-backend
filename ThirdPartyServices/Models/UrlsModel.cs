namespace AzureBlobStorage.Models
{
    public class UrlsModel
    {
        public string Url { get; }

        public UrlsModel(string filepath)
        {
            Url = filepath;
        }
    }
}
