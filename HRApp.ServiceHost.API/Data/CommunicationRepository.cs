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
