using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.CombinedLogInfo
{
    internal class CombinedLogInfoPoco
    {
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Object { get; set; }
    }
}