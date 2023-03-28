using dotnetFirstAPI.Data;
using dotnetFirstAPI.Entities;
using dotnetFirstAPI.Interface;
using Microsoft.EntityFrameworkCore;

namespace dotnetFirstAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUploadFileService uploadFileService;
        public ProductService(DatabaseContext databaseContext, IUploadFileService iuploadFileService)
        {
            this.uploadFileService = uploadFileService;
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            return await databaseContext.Products.Include(p => p.Category)
                    .OrderByDescending(p => p.ProductId)
                    .ToListAsync();
        }

        public async Task<Product> FindById(int id)
        {
            return await databaseContext.Products.Include(p => p.Category)
            .SingleOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Product>> SearchProdcut(string name)
        {
            return await databaseContext.Products.Include(p => p.Category)
                     .Where(paramitre => paramitre.Name.ToLower().Contains(name.ToLower()))
                     .ToListAsync();
        }
        public async Task CreateProdcut(Product product)
        {
            databaseContext.Products.Add(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            databaseContext.Update(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            databaseContext.Products.Remove(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<(string errorMessage, string imageName)> UploadImage(List<IFormFile> formFiles)
        {
            string errorMessage = String.Empty;
            string imageName = String.Empty;
            if(uploadFileService.IsUpload(formFiles)){
                errorMessage = uploadFileService.Validation(formFiles);
                if(string.IsNullOrEmpty(errorMessage)){
                    imageName = (await uploadFileService.UploadImage(formFiles))[0];
                }
            };

            return (errorMessage, imageName);
        }
    }
}