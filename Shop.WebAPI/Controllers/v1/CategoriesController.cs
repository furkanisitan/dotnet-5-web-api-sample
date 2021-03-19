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
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.FindAll();
            return Ok(categories);
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var category = _categoryService.FindById(id);
            return category == null ? this.FailedNotFound(nameof(Category), (nameof(id), id)) : Ok(category);
        }

        [HttpGet("{id:int:min(1)}/products")]
        public IActionResult GetProductsById([FromRoute] int id)
        {
            var products = _productService.FindAllByCategoryId(id);
            return Ok(products);
        }

        [HttpPost]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Add([FromBody] Category category)
        {
            var result = _categoryService.Add(category);
            return result.IsSuccess
                ? CreatedAtAction(nameof(GetById), new { id = category.Id }, category)
                : this.FailedFromServiceResult(result);
        }

        [HttpPut("{id:int:min(1)}")]
        [Authorize(Roles = "admin,employee")]
        public IActionResult Update([FromRoute] int id, [FromBody] Category category)
        {
            category.Id = id;
            var result = _categoryService.Update(category);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

        [HttpDelete("{id:int:min(1)}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var result = _categoryService.RemoveById(id);
            return result.IsSuccess ? NoContent() : this.FailedFromServiceResult(result);
        }

    }
}
