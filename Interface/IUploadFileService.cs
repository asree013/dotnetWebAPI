namespace dotnetFirstAPI.Interface
{
    public interface IUploadFileService
    {
         bool IsUpload(List<FormFile> formFiles);
         string Validation(List<FormFile> formFile);
         Task<List<string>> UploadImage(List<FormFile> formFiles);
    }
}