using Business.Abstract;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPut("update")]
        public IActionResult Update(Member member) 
        { 
            var result = _memberService.Update(member);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id) 
        { 
            var result = _memberService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _memberService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int memberId) 
        {
            var result = _memberService.GetById(memberId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallwithdetails")]
        public IActionResult GetMemberDetails() 
        {
            var result = _memberService.GetMemberDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyidwithdetails")]
        public IActionResult GetMemberDetailsById(int memberId)
        {
            var result = _memberService.GetMemberDetailsById(memberId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getmembercampaigns")]
        public IActionResult GetMemberCampaignDetails()
        {
            var result = _memberService.GetMemberCampaignDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getmembercampaigndetailbymemberid")]
        public IActionResult GetMemberCampaignDetailByUserId(int memberId)
        {
            var result = _memberService.GetMemberCampaignDetailByUserId(memberId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}