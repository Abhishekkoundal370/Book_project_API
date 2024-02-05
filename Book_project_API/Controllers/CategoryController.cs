using Book_Project.Model.Model;
using Book_Project.Services.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Project_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
         var categoryList = _categoryRepository.GetAll();
            return Json(categoryList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepository.Get(id);
            return Json(category);
        }
        [HttpPost]
        public IActionResult Add([FromBody] Category model)
        {
            if(model != null)
            {
                _categoryRepository.Add(model);
                return Ok("Category added succefully");
            }
            return BadRequest("Category is Null");
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Category model)
        {
            if(model != null)
            {
                _categoryRepository.Update(model);
                return Ok("Category Updated successfully");
            }
            return BadRequest("Category is null");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id != 0)
            {
                _categoryRepository.Remove(id);
                return Ok("Category Deleted Successfully");
            }
            return BadRequest("Category Id is not present");
        }
    }
}
