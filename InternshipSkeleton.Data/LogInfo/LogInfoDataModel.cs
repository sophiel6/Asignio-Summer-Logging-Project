using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.LogInfo
{
    public class LogInfoDataModel
    {
        public DateTime TimeStamp { get; set; }
        public Guid WebRequestID { get; set; }
        public Guid UserID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Object { get; set; }
        public Guid ID { get; set; }

    }
}