using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.CombinedLogException
{
    internal class CombinedLogExceptionPoco
    {
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string Important { get; set; }
    }
}