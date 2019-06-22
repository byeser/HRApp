using HRApp.ServiceHost.API.Contracts;
using HRApp.ServiceHost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Business
{
   public interface ICommunicationBusiness
    {
        /// <summary>
        /// return communication information by user id
        /// </summary>
        /// <param name="userid">User Id</param>
        /// <returns>Task<CommunicationResponse> </returns>
        Task<CommunicationResponse> GetByUserIdAsync(long userid);
        /// <summary>
        /// new record Communication
        /// </summary>
        /// <param name="communication">Communication class</param>
        /// <returns></returns>
        Task AddAsync(Communication communication);
    }
}
