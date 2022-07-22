using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.WebAPI.Data;
using User.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace User.WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<UserModel> GetAsync(int Id)
        {
            return await _db.Users.FirstOrDefaultAsync(x=> x.Id == Id);
        }
        public async Task<UserModel> AddAsync(UserModel user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }
        public async Task<UserModel> DeleteAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;

            }
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
