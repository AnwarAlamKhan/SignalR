using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebRestAPI.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DBRepo _db;
        public LoginController(IConfiguration config, DBRepo db)
        {
            _config = config;
            _db = db;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public ActionResult Login(string userLogin)
        {

            var token = GenerateToken(userLogin);

            return Ok(token.ToString());

        }



        [HttpGet("GetSubscribers")]
        public ActionResult GetSubscribers()
        {
            return Ok(_db.GetSubscribers());
        }
        private string GenerateToken(string user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user),

            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        private bool Authenticate(string userLogin)
        {
            if (userLogin == "anwar")
                return true;

            return false;

        }
    }
}
