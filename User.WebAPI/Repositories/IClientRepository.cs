namespace User.WebAPI.Repositories
{
    public interface  IClientRepository
    {

       Task<bool> AuthenticateAsync(string username, string password);

    }
}
