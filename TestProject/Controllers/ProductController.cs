using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Model;
using TestProject.Repository.Interface;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRespositroy _productrepo;

        public ProductController(IProductRespositroy productrepo)
        {
            _productrepo = productrepo;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productrepo.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productrepo.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> PostProduct(Product product)
        {
            try
            {
                await _productrepo.AddProduct(product);
                return Ok(new { message = "Product created successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutProduct(int id,Product product)
        {          
            try
            {
                var existingProduct = await _productrepo.GetProductById(id);
                if (existingProduct == null)
                {
                    return NotFound("Product not found");
                }

                await _productrepo.UpdateProduct(product);
                return Ok(new { message = "Product updated successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productrepo.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }

                await _productrepo.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}
