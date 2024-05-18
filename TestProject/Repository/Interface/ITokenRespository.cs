using Microsoft.AspNetCore.Identity;

namespace TestProject.Repository.Interface
{
    public interface ITokenRespository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
