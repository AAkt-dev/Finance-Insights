using Finance_Insights.Service_Contracts;
using Finance_Insights.Shared.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Insights.Presentation.Controllers
{
    [ApiController]
    [Route("api/Account/{accountId}/Category/")]
    public class CategoryController:ControllerBase
    {
        private readonly IServiceManager _service;
        public CategoryController(IServiceManager serviceManager)
        {
            this._service = serviceManager;
        }
        [HttpGet]
        public IActionResult GetAllCategory(Guid accountId)
        {
            var categories=_service.categoryService.GetAllAccountofCategory(accountId, trackChanges: false);
            return Ok(categories);
        }
        [HttpGet("{categoryId:guid}",Name ="GetCategory")]
        public IActionResult GetCategory(Guid categoryId)
        {
            var category=_service.categoryService.GetCategory(categoryId,tracChanges: false);
            return Ok(category);
        }
        [HttpPost]
        public IActionResult AddCategory(Guid accountId, [FromBody]CategoryDto categoryToAdd)
        {
            if (categoryToAdd == null)
            {
                return BadRequest("Category provided is null");
            }
            var category=_service.categoryService.AddCategory(categoryToAdd, accountId, trackChanges: false);
            return CreatedAtRoute("GetCategory", new { categoryId = category.CategoryId ,accountId}, category);
        }
        [HttpDelete("{categoryId:guid}")]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            _service.categoryService.DeleteCategory(categoryId,trackChanges:false);
            return NoContent();
        }
        [HttpPatch("{categoryId:guid}")]
        public IActionResult UpdateCategory(Guid categoryId, [FromBody]JsonPatchDocument<CategoryDto> document)
        {
            if (document == null)
            {
                return BadRequest("Category to Update is null");
            }
            var result = _service.categoryService.GetCategoryforPatch(categoryId, trackChanges: true);
            document.ApplyTo(result.categoryForPatch);
            _service.categoryService.SaveChangesForPatch(result.categoryForPatch,result.categoryEntity);
            return NoContent();
        }
    }
}
