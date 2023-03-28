using System.Collections.Generic;
using dotnetFirstAPI.Entities;

namespace dotnetFirstAPI.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> FindAll();
        Task<Product> FindById(int id);
        Task CreateProdcut(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
        Task<IEnumerable<Product>> SearchProdcut(string Name);
        Task<(string errorMessage, string imageName)> UploadImage(List<IFormFile> formFiles);
    }
}