using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.CombinedLogWebResponse
{
    internal class CombinedLogWebResponsePoco
    {
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public string Status { get; set; }
        public string RedirectLocation { get; set; }
    }
}