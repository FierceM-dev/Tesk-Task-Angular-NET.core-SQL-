using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_TestTask_.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public string EmailUser { get; set; }
        public string Phone { get; set; }
        public string Theme { get; set; }
        public string NameUser { get; set; }
    }
}
