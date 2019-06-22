using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRApp.ServiceHost.API.Models;
using Dapper;

namespace HRApp.ServiceHost.API.Data
{
    public class UserRepository : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            using (var dbConnection = Connection.GetDbConnection())
            {
                string query = @"INSERT INTO [dbo].[users] (
                                [fullname],
                                [username],
                                [password],
                                [role]) VALUES (
                                @fullname,
                                @username,
                                @password,
                                @role)";
                await dbConnection.ExecuteAsync(query, user);
            }
        }

        public async Task<User> Authenticate(string username, string password)
        {
            using (var dbConnection = Connection.GetDbConnection())
            {
                string query = @"SELECT *
                                FROM [dbo].[users]
                                WHERE username= @UserName and password= @Password";

                return await dbConnection.QueryFirstOrDefaultAsync<User>(query, new { @UserName = username, @Password =password});
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var dbConnection = Connection.GetDbConnection())
            {
                string query = @"SELECT *
                                FROM [dbo].[users]";
                return await dbConnection.QueryAsync<User>(query);

            }
        }

        public async Task<User> GetAsync(long id)
        {
            using (var dbConnection = Connection.GetDbConnection())
            {
                string query = @"SELECT *
                                FROM [dbo].[users]
                                WHERE [id] = @Id";

                return await dbConnection.QueryFirstOrDefaultAsync<User>(query, new { @Id = id });
            }
        }

        public async Task UpdateAsync(User user)
        {
            using (var dbConnection = Connection.GetDbConnection())
            {
                string query = @"UPDATE [dbo].[users] SET 
                                fullname=@fullname,
                                username=@username,
                                password=@password,
                                role=@role WHERE id=" + user.id;
                await dbConnection.ExecuteAsync(query, user);
            }
        }
    }
}
