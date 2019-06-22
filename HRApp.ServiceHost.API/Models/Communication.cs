using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApp.ServiceHost.API.Models
{
    public class Communication
    {
        public int id { get; set; } = 0;
        public int user_id { get; set; } = 0;
        public byte type { get; set; } = 0;
        public string descriptions { get; set; } = string.Empty;

    }
}
