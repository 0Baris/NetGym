using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerMemberController : ControllerBase
    {
        private readonly IDealerMemberService _dealerMemberService;
        
        public DealerMemberController(IDealerMemberService dealerMemberService)
        {
            _dealerMemberService = dealerMemberService;
        }

        [HttpPost("add")]
        public IActionResult Add(DealerMember dealerMember)
        {
            var result = _dealerMemberService.Add(dealerMember);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(DealerMember dealerMember)
        {
            var result = _dealerMemberService.Update(dealerMember);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _dealerMemberService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int dealerId)
        {
            var result = _dealerMemberService.GetAllWithDealers(dealerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}