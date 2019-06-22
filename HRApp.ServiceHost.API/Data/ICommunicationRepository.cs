using HRApp.ServiceHost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Data
{
   public interface ICommunicationRepository
    {
        Task<IEnumerable<Communication>> GetByUserIdAsync(long userid);
    }
}
