using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.CombinedLogException
{
    public class CombinedLogExceptionDataModel
    {
        //not 100% sure about which fields to include in this data model (besides email and userID)
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid WebRequestID { get; set; }
        public Guid UserID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }

    }
}

