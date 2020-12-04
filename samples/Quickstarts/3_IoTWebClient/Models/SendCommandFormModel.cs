using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebClient.Models
{
    public class SendCommandFormModel
    {
        public string Connection { get; set; }
        public string Command { get; set; }
    }
}
