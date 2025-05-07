using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpPost("add")]
        public IActionResult Add(Trainer trainer)
        {
            var result = _trainerService.Add(trainer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Trainer trainer)
        {
            var result = _trainerService.Update(trainer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _trainerService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _trainerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _trainerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getallwithdetails")]
        public IActionResult GetTrainerDetails()
        {
            var result = _trainerService.GetTrainerDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
            
        }

        [HttpGet("getbyidwithdetails")]
        public IActionResult GetTrainerDetailsById(int id)
        {
            var result = _trainerService.GetTrainerDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}