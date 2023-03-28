using System.Collections.Generic;
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

        public bool IsUpload(List<IFormFile> formFiles) => formFiles != null && formFiles.Sum(f => f.Length) > 0;

        public string Validation(List<IFormFile> formFiles)
        {
            foreach (var formFile in formFiles) {
                if(!ValidationExtention(formFile.FileName)){
                    return "Invalid File Extension";
                }
                if(ValidationSize(formFile.Length)){
                    return "Invalid file Extension";
                }
            }
            return null;
        }

        public async Task<List<string>> UploadImage(List<IFormFile> formFiles)
        {
            List<string> listFileName = new List<string>();
            string uploadPath = $"{webHostEnvironment.WebRootPath}/images";
            foreach (var formFile in formFiles) {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                string fullPath = uploadPath + fileName;
                using(var stream = File.Create(fullPath)){
                    await formFile.CopyToAsync(stream);
                }
                listFileName.Add(fileName);
            }
            return listFileName;
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