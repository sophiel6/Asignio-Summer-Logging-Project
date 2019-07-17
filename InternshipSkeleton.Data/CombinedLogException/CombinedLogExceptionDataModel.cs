using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.CombinedLogException
{
    public class CombinedLogExceptionDataModel
    {
        public Guid UserID { get; set; }
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid WebRequestID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string Important { get; set; }

    }
}

