using System.Net;
using System.Linq;
using dotnetFirstAPI.Data;
using dotnetFirstAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetFirstAPI.DTOs.Product;
using Mapster;
using dotnetFirstAPI.Interface;

namespace dotnetFirstAPI.Controllers;

[ApiController] //[...] = data annotation
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService productService;
    public ProductsController(IProductService productService) => this.productService = productService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProdcuts()
    {
        return (await productService.FindAll()).Select(ProductResponse.FormProdcut).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProductByID(int id)
    {
        var product = await productService.FindById(id);
        if (product == null)
        {
            return NotFound();
        }
        return product.Adapt<ProductResponse>();
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> SearchProduct([FromQuery] string name = "")
    {
        return (await productService.SearchProdcut(name))
                     .Select(ProductResponse.FormProdcut)
                     .ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProdcut([FromForm] ProductRequest productRequest)
    {
        var product = productRequest.Adapt<Product>();
        await productService.CreateProdcut(product);
        return StatusCode((int)HttpStatusCode.Created);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(int id, [FromForm] ProductRequest prodcutRequest)
    {
        if (id != prodcutRequest.ProductId)
        {
            return BadRequest();
        }
        var product = await productService.FindById(id);

        if (product == null)
        {
            return NotFound();
        }
        prodcutRequest.Adapt(product);

        await productService.UpdateProduct(product);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProductsById(int id)
    {
        var product = await productService.FindById(id);
        if (product == null)
        {
            return NotFound();
        }
        await productService.DeleteProduct(product);

        return NoContent();
    }

}
