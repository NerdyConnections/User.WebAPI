using User.Domain.Models;

namespace User.WebAPI.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(Client client);
    }
}
