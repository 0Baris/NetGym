using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly IDealerService _dealerService;

        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }
        
        [HttpPost("add")]
        public IActionResult Add(Dealer dealer)
        {
            var result = _dealerService.Add(dealer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Dealer dealer)
        {
            var result = _dealerService.Update(dealer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _dealerService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _dealerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int dealerId)
        {
            var result = _dealerService.GetById(dealerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        
        [HttpGet("getallwithdetails")]
        public IActionResult GetAllWithDetails()
        {
            var result = _dealerService.GetDealerDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyidwithdetailsbyid")]
        public IActionResult GetByIdWithDetails(int dealerId)
        {
            var result = _dealerService.GetDealerDetailsById(dealerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("region/{region}")]
        public IActionResult GetByRegion(string region)
        {
            var result = _dealerService.GetByRegion(region);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}