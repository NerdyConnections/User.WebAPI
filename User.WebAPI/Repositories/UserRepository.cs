using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.WebAPI.Data;
using User.Domain.Models;

namespace User.WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<UserModel> GetAll()
        {
            return _db.Users.ToList();
        }
    }
}
