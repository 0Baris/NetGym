using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
            IMemberService _memberService;
            
            public MemberController(IMemberService memberService)
            {
                _memberService = memberService;
            }
            
            [HttpPost("add")]
            public IActionResult Add(Member member)
            {
                var result = _memberService.Add(member);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            
    }
}