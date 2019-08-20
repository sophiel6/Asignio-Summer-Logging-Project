using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogWebResponse
{
    [PetaPoco.TableName("logwebresponse")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)]
    internal class LogWebResponsePoco
    {
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string RedirectLocation { get; set; }
    }
}
