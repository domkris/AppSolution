//Code from https://github.com/MosheWorld/AuthenticationService

using System.Collections.Generic;
using System.Security.Claims;
using WebApp.NETCore.Models;

namespace WebApp.NETCore.Managers
{
    public interface IAuthService
    {
        string SecretKey { get; set; }
        bool IsTokenValid(string token);
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
