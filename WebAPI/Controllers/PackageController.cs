using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }
        
        [HttpPost("add")]
        public IActionResult Add([FromBody] Package package)
        {
            var result = _packageService.Add(package);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPut("update")]
        public IActionResult Update([FromBody] Package package)
        {
            var result = _packageService.Update(package);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int packageId)
        {
            var result = _packageService.Delete(packageId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _packageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _packageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}