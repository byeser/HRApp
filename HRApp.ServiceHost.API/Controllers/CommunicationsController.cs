using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRApp.ServiceHost.API.Business;
using HRApp.ServiceHost.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.ServiceHost.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CommunicationsController : ControllerBase
    {
        private readonly ICommunicationBusiness _communicationBusiness;
        public CommunicationsController(ICommunicationBusiness communicationBusiness)
        {
            _communicationBusiness = communicationBusiness;
        }
        [HttpGet("GetByUserIdAsync/{userid}")]
        public async Task<CommunicationResponse> GetByUserIdAsync(long userid)
        {
            return await _communicationBusiness.GetByUserIdAsync(userid);
        }
    }
}