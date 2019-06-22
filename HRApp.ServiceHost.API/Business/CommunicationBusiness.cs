using HRApp.ServiceHost.API.Contracts;
using HRApp.ServiceHost.API.Data;
using HRApp.ServiceHost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Business
{
    public class CommunicationBusiness : ICommunicationBusiness
    {
        private readonly ICommunicationRepository _communicationRepository;
        public CommunicationBusiness(ICommunicationRepository communicationRepository)
        {
            _communicationRepository = communicationRepository;
        }
        public async Task<CommunicationResponse> GetByUserIdAsync(long userid)
        {
            IEnumerable<Communication> com = await _communicationRepository.GetByUserIdAsync(userid);
            var response = new CommunicationResponse();
            if (com.ToList().Count == 0)
                response.Message = "Kayıt bulunamadı !";
            else
                response.Communications.AddRange(com);
            return response;
        }
    }
}
