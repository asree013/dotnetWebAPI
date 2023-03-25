using System.ComponentModel.DataAnnotations;

namespace dotnetFirstAPI.DTOs.Product
{
    public class ProductRequest
    {
        public int? ProductId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "NAME OVER LIMITED")]
        public string Name { get; set; } = null!;
        [Range(0, 1000)]
        public int Stock { get; set; }
        [Range(0, 100_000)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public List<IFormFile> FormFiles { get; set; } = null!;

    }
}