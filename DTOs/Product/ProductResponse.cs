
namespace dotnetFirstAPI.DTOs.Product
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string? Image { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string CatagoryName { get; set; } = null!;

        public static ProductResponse FormProdcut(dotnetFirstAPI.Entities.Product product){
            return new ProductResponse{
                ProductId = product.ProductId,
                Name = product.Name,
                Image = product.Image,
                Stock = product.Stock,
                Price = product.Price,
                CatagoryName = product.Category.Name
            };
        }
    }
}