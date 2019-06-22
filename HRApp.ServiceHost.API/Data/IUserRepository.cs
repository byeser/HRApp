using HRApp.ServiceHost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Data
{
    public interface IUserRepository
    {
        Task<User> GetAsync(long id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> Authenticate(string username, string password);
    }
}
