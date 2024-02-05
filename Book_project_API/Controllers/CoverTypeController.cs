using Book_Project.Model.Model;
using Book_Project.Services.Repository;
using Book_Project.Services.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Book_Project_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeRepository _coverTypeRepository;
        // private readonly ApplicationDbContext _context;
        public CoverTypeController(ICoverTypeRepository coverTypeRepository)
        {
            _coverTypeRepository = coverTypeRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var CoverType = _coverTypeRepository.GetAll();
            return Json(CoverType);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var covertypebyid = _coverTypeRepository.Get(id);
            return Json(covertypebyid);
        }
        [HttpPost]
        public IActionResult Add([FromBody] Covertype model)
        {
            if(model != null)
            {
                _coverTypeRepository.Add(model);
                return Ok("CoverType Added Successfully");
            }
            return BadRequest("CoverType is Denied");
        }
        [HttpPut]
        public IActionResult Edit([FromBody] Covertype model)
        {
            if(model != null)
            {
                _coverTypeRepository.Update(model);
                return Ok("Covertype Updated Successfully");
            }
            return BadRequest("Covertype Denied !!");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            if(id !=0 )
            { 
            _coverTypeRepository.Remove(id);
            return Ok("Data deleted Sucessfully");
            }
            return BadRequest("Data Not delleted successfully!!");
        }
    }
}
