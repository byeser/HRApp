using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRApp.ServiceHost.API.Models;
using Dapper;

namespace HRApp.ServiceHost.API.Data
{
    public class CommunicationRepository : ICommunicationRepository
    {
        /// <summary>
        /// new record Communication
        /// </summary>
        /// <param name="communication">Communication class</param>
        /// <returns>Task Communication class</returns>
        public async Task AddAsync(Communication communication)
        {
            using (var dbConnection = Connection.GetDbConnection())
            {
                string query = @"INSERT INTO [dbo].[communications] (
                                [user_id],
                                [type],
                                [descriptions]) VALUES (
                                @user_id,
                                @type,
                                @descriptions)";
                await dbConnection.ExecuteAsync(query, communication);
            }
        }
        /// <summary>
        /// return communication information by user id
        /// </summary>
        /// <param name="userid">user id</param>
        /// <returns>Task<IEnumerable<Communication>> </returns>
        public async Task<IEnumerable<Communication>> GetByUserIdAsync(long userid)
        {
            using (var dbConnection = Connection.GetDbConnection())
            {
                string query = @"SELECT *
                                FROM [dbo].[communications]
                                WHERE [user_id] =" + userid;

                return await dbConnection.QueryAsync<Communication>(query);
            }
        }
    }
}
