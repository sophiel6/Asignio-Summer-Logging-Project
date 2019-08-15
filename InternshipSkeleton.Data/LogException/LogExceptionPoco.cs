using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogException
{
    [PetaPoco.TableName("logexception")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)]
    internal class LogExceptionPoco
    {
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
    }
}