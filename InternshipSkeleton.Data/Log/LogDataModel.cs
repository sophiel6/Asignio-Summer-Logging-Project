using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.Log
{
    public class LogDataModel
    {
        public DateTime TimeStamp { get; set; }
        public Guid LogID { get; set; }
        public Guid UserID { get; set; }
        public string Message { get; set; }
        public string Username { get; set; }
        public string Source { get; set; }
        public int Level { get; set; }
    }
}