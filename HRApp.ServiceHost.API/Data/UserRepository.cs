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
        /// <summary>
        /// new user record
        /// </summary>
        /// <param name="user">User class</param>
        /// <returns>Task User</returns>
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
        /// <summary>
        ///   jwt token and User class
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns> Task<User></returns>
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
        /// <summary>
        /// get all user list
        /// </summary>
        /// <returns> Task<IEnumerable<User>></returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var dbConnection = Connection.GetDbConnection())
            {
                string query = @"SELECT *
                                FROM [dbo].[users]";
                return await dbConnection.QueryAsync<User>(query);

            }
        }
        /// <summary>
        /// get by user id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns> Task<User></returns>
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
        /// <summary>
        /// update User
        /// </summary>
        /// <param name="user">User class</param>
        /// <returns>Task User</returns>
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
