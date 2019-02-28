// Auth code from https://github.com/MosheWorld/AuthenticationService

using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Models.Administration;
using WebApp.NETCore.Managers;
using WebApp.NETCore.Models;

namespace WebApp.NETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext context;

        public LoginController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public string Start()
        {
            return "Welcome";
        }

        [HttpPost]
        public IActionResult PostLogin([FromBody] UserLogin userLogin) 
        {
            
            var user = context.Users
                              .Where(x=> x.Username == userLogin.Username)
                              .FirstOrDefault();
            var exists = user == null;
            if (!exists)
            {
                IAuthContainerModel model = GetJWTContainerModel(user.Username, user.PasswordHash);
                IAuthService authService = new JWTService(model.SecretKey);

                string token = authService.GenerateToken(model);
                if (!authService.IsTokenValid(token))
                {
                    var jsonResult = new { success = false, err = "Invalid username or password", token = (string) null };
                    return new JsonResult(jsonResult);
                }
                else
                {
                    var jsonResult = new { success = true, err = (string) null, token };
                    return new JsonResult(jsonResult);
                }
            }
            else
            {
                var jsonResult = new { success = false, err = "Invalid username or password", token = (string) null};
                return new JsonResult(jsonResult);
            }
            
        }

        private static JWTContainerModel GetJWTContainerModel(string name, string password)
        {
            return new JWTContainerModel()
            {
                Claims = new System.Security.Claims.Claim[]
                {
                    new Claim(ClaimTypes.Name,name),
                    new Claim(ClaimTypes.Hash, password)
                }
            };
        }

    }
}