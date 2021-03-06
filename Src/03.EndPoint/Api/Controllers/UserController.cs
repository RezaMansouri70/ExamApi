using ApplicationServices.Models.UserModels;
using ApplicationServices.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/User/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;


        private readonly IUserService _userService;



        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }


        [HttpPost("Register")]
        public IActionResult Register([FromBody] AddUserDto addUser)
        {
            var user = _userService.Register(addUser);
            if (user != null)
                return StatusCode(201);
            return StatusCode(500);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserDto login)
        {

            if (_userService.CanLogin(login))
            {
                var tokenString = GenerateJSONWebToken(login.Mobile);
                return Ok(new { token = tokenString });
            }
            else
                return StatusCode(401);

        }

        private string GenerateJSONWebToken(string mobile)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {

                new Claim(JwtRegisteredClaimNames.NameId, mobile),
                new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       

    }
 

}
