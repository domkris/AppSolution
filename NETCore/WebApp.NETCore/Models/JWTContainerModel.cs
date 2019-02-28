//Code from https://github.com/MosheWorld/AuthenticationService

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace WebApp.NETCore.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        public int ExpireMinutes { get; set; } = 10080;
        public string SecretKey { get; set; } = "5jP7DTrHa71TgeXnobdc9bdm8dv7";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public Claim[] Claims { get; set;} 
    }
}
