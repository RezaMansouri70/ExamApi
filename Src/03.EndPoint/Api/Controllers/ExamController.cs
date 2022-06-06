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
            var currentUser = HttpContext.User.Claims.First().Value;
            var result = _userexamService.MakeExam(addModel, currentUser);
            return StatusCode(201, result.Id);
        }
        [HttpGet("GetAll")]
        [Authorize]
        public IActionResult GetAll([FromQuery] string pageNumber= "1", string pageSize= "5")
        {
            var currentUser = HttpContext.User.Claims.First().Value;
            var result = _userexamService.GetExam( int.Parse( pageNumber), int.Parse( pageSize), currentUser);
            return Ok(result);
        }

        [HttpPut("Update")]
        [Authorize]
        public IActionResult Update([FromBody] EditUserExamDto editModel)
        {
            var currentUser = HttpContext.User.Claims.First().Value;
            var result = _userexamService.Edit(editModel, currentUser);
            return Ok(result.Id);
        }

        [HttpDelete("Delete")]
        [Authorize]
        public IActionResult Delete([FromQuery] int Id)
        {
            var currentUser = HttpContext.User.Claims.First().Value;
            var result = _userexamService.Delete(Id, currentUser);
            return Ok(result);
        }
    }
}
