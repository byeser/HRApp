using HRApp.ServiceHost.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Contracts
{
    public class CommunicationResponse
    {
        public CommunicationResponse()
        {
            Communications = new List<Communication>();
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public List<Communication> Communications { get; set; }
    }
}
