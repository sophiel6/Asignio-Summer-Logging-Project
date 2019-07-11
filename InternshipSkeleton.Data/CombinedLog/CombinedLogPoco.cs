using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.CombinedLog
{
    internal class CombinedLogPoco
    {
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] LogID { get; set; }
        public int Level { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
    }
}