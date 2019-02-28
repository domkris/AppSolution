//Code from https://github.com/MosheWorld/AuthenticationService
using System.Security.Claims;

namespace WebApp.NETCore.Models
{
    public interface IAuthContainerModel
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }
        Claim[] Claims { get; set; }
    }
}
