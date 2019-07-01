using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.LogMySql
{
    public class LogMySqlDataModel
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string Function { get; set; }
        public int Type { get; set; }
    }
}