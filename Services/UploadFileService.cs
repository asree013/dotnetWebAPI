using dotnetFirstAPI.Interface;

namespace dotnetFirstAPI.Services
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration Configuration;

        public UploadFileService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.Configuration = configuration;
        }

        public bool IsUpload(List<FormFile> formFiles) => formFiles != null && formFiles.Sum(f => f.Length) > 0;

        public string Validation(List<FormFile> formFile)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> UploadImage(List<FormFile> formFiles)
        {
            throw new NotImplementedException();
        }

        public bool ValidationExtention(string fileName)
        {
            string[] premittedExtention = {".jpg", ".png"};
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            if(string.IsNullOrEmpty(ext) || !premittedExtention.Contains(ext)){
                return false;
            }
            return true;
        }

        public bool ValidationSize(long fileSize) => Configuration.GetValue<long>("FileSizeLimit") > fileSize;
    }
}