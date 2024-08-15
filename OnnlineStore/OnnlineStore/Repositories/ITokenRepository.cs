using Microsoft.AspNetCore.Identity;

namespace OnnlineStore.Repositories
{
    public interface ITokenRepository
    {
        Task<string> CreateJwtTokenAsync(IdentityUser user, List<string> roles);
    }
}
