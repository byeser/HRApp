using HRApp.ServiceHost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Data
{
   public interface ICommunicationRepository
    {
        /// <summary>
        /// return communication information by user id
        /// </summary>
        /// <param name="userid">user id</param>
        /// <returns>Task<IEnumerable<Communication>></returns>
        Task<IEnumerable<Communication>> GetByUserIdAsync(long userid);
        /// <summary>
        /// new record Communication
        /// </summary>
        /// <param name="communication">Communication class</param>
        /// <returns>Task Communication</returns>
        Task AddAsync(Communication communication);

    }
}
