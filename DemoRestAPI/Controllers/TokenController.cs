using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.AspNetCore.Cors;
using BLL;
using BLL.BusinessObjects;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AppRestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("/api/token")]
    public class TokenController : Controller
    {
        BLLFacade _facade;
        public TokenController(BLLFacade facade)
        {
            _facade = facade;
        }
        [HttpPost]
        public IActionResult Create(string username, string password)
        {
            var user = IsValidUserAndPasswordCombination(username, password);
            if (user != null && !string.IsNullOrEmpty(username))
            {
                var token = GenerateToken(user);
                return new ObjectResult(token);
            }
            return BadRequest();
        }
        private UserBO IsValidUserAndPasswordCombination(string username, string password)
        {
            List<UserBO> list = _facade.UserService.GetAll();
            var userFound = list.FirstOrDefault(u => u.Username == username && u.Password == password);
            return userFound;
        }
        private IActionResult GenerateToken(UserBO user)
        {
            var claims = new List<Claim>
            {
                new Claim("username", user.Username),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            if (user.Role == "Administrator")
                claims.Add(new Claim("role", "Administrator"));


            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BOErgeOsTSpiser AErter 123 STK I ALT!")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
=======

namespace AppRestAPI.Controllers
{
    public class TokenController : Controller
    {
        public IActionResult Index()
        {
            return View();
>>>>>>> d3ac035017e861c08938f7db785fdeacd09da49d
        }
    }
}