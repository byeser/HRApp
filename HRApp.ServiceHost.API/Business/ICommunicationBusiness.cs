using HRApp.ServiceHost.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Business
{
   public interface ICommunicationBusiness
    {
        Task<CommunicationResponse> GetByUserIdAsync(long id);
    }
}
