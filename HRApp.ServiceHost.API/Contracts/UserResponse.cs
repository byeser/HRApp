using HRApp.ServiceHost.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Contracts
{
    public class UserResponse
    {
        public UserResponse()
        {
            Users = new List<User>();
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public List<User> Users { get; set; }
    }
}
