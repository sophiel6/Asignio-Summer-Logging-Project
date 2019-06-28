﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignioInternship.Data.LogControllerAction
{
    public class LogControllerActionDataModel
    {
        public DateTime TimeStamp { get; set; }
        public Guid WebRequestID { get; set; }
        public Guid UserID { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Parameters { get; set; }
    }

}