using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Business.Abstract;
using Shop.Entities.Concrete;
using Shop.WebAPI.Utilities.Extensions;

namespace Shop.WebAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int? categoryId)
        {
            var products = categoryId == null
                ? _productService.FindAll()
                : _productService.FindAllByCategoryId(categoryId.Value);
            return Ok(products);
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _productService.FindById(id);
            return product == null ? this.FailedNotFound(nameof(Product), (nameof(id), id)) : Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Add([FromBody] Product product)
        {
            var result = _productService.Add(product);
            return result.IsSuccess
                ? CreatedAtAction(nameof(GetById), new { id = product.Id }, product)
                : this.FailedFromServiceResult(result);
        }

        [HttpPut("{id:int:min(1)}")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Update([FromRoute] int id, [FromBody] Product product)
        {
            product.Id = id;
            var result = _productService.Update(product);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var result = _productService.RemoveById(id);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

    }
}
