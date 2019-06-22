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
        /// <summary>
        /// new record Communication
        /// </summary>
        /// <param name="communication">Communication class</param>
        /// <returns></returns>
        public async Task AddAsync(Communication communication)
        {
            await _communicationRepository.AddAsync(communication);
        }
        /// <summary>
        /// return communication information by user id
        /// </summary>
        /// <param name="userid">User Id</param>
        /// <returns>Task<CommunicationResponse> </returns>
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
