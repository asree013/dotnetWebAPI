namespace dotnetFirstAPI.Interface
{
    public interface IUploadFileService
    {
         bool IsUpload(List<IFormFile> formFiles);
         string Validation(List<IFormFile> formFile);
         Task<List<string>> UploadImage(List<IFormFile> formFiles);
    }
}