using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IPackageService _packageService;
        
        public SubscriptionController(IMemberService memberService, ISubscriptionService subscriptionService, IPackageService packageService)
        {
            _memberService = memberService;
            _subscriptionService = subscriptionService;
            _packageService = packageService;
        }

                
        [HttpPost("add")]
        public IActionResult Add(Subscription subscription)
        {
            var result = _subscriptionService.Add(subscription);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPut("update")]
        public IActionResult Update(Subscription subscription)
        {
            var result = _subscriptionService.Update(subscription);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _subscriptionService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _subscriptionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _subscriptionService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
                
        [HttpGet("getallbydetails")]
        public IActionResult GetAllByDetails()
        {
            var result = _subscriptionService.GetAllByDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getdetailsbyid")]
        public IActionResult GetDetailsById(int memberId)
        {
            var result = _subscriptionService.GetDetailsById(memberId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}