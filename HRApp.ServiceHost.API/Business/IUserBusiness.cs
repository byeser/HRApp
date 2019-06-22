using HRApp.ServiceHost.API.Contracts;
using HRApp.ServiceHost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Business
{
    public interface IUserBusiness
    {
        Task<UserResponse> GetAsync(long id);
        Task<UserResponse> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User> Authenticate(string username, string password);
    }
}
