using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Models;

namespace User.WebAPI.Repositories
{
    public interface  IUserRepository
    {
        Task<IEnumerable<UserModel>> GetAllAsync();

        Task<UserModel> GetAsync(int Id);


        Task<UserModel> AddAsync(UserModel user);

        Task<UserModel> DeleteAsync(int id);

        Task<UserModel> UpdateAsync(int id, UserModel userModel);


    }
}
