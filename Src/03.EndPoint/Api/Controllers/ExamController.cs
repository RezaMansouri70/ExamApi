using ApplicationServices.Models.UserExam;
using ApplicationServices.Services.UserExam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IUserExamService _userexamService;
        public ExamController(IUserExamService UserexamService)
        {
            this._userexamService = UserexamService;
        }

        [HttpPost("AddExam")]
        [Authorize]
        public IActionResult Post([FromBody]AddUserExamDto addModel)
        {
            var result = _userexamService.MakeExam(addModel, getCurrentUserMobile());
            return StatusCode(201, result.Id);
        }
        [HttpGet("GetAll")]
        [Authorize]
        public IActionResult GetAll([FromQuery] string pageNumber= "1", string pageSize= "5")
        {
            var result = _userexamService.GetExam( int.Parse( pageNumber), int.Parse( pageSize), getCurrentUserMobile());
            return Ok(result);
        }

        [HttpPut("Update")]
        [Authorize]
        public IActionResult Update([FromBody] EditUserExamDto editModel)
        {
            var result = _userexamService.Edit(editModel, getCurrentUserMobile());
            return Ok(result.Id);
        }

        [HttpDelete("Delete")]
        [Authorize]
        public IActionResult Delete([FromQuery] int Id)
        {
            var result = _userexamService.Delete(Id, getCurrentUserMobile());
            return Ok(result);
        }
        private string? getCurrentUserMobile() 
        {
            if (HttpContext.User.Claims.Any())
                return HttpContext.User.Claims.First().Value;
            return null;
        }
    }
}
