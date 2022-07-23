using User.Domain.Models;

namespace User.WebAPI.Repositories
{
    public class StaticUserRepository : IClientRepository
    {
        //harding coding valid users for demo but easily change to db with depending injection with a different repository
        private List<Client> Clients = new List<Client>()
        {
            new Client()
            {
                FirstName="Read Only", LastName="User", EmailAddress="readonly@user.com",
                Id=1,Username="readonly@user.com", Password="readonly@user.com",
                Roles = new List<string> {"reader"}
            },
             new Client()
            {
                FirstName="Read Write", LastName="User", EmailAddress="readwrite@user.com",
                Id=1,Username="readwrite@user.com", Password="readwrite@user.com",
                Roles = new List<string> {"reader","writer"}
            }
        };

        public async Task<Client> AuthenticateAsync(string username, string password)
        {
           var client= Clients.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);

            return client;
        }
    }
}
