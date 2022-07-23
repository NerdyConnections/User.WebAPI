using User.Domain.Models;

namespace User.WebAPI.Repositories
{
    public interface  IClientRepository
    {

       Task<Client> AuthenticateAsync(string username, string password);

    }
}
