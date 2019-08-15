﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsignioInternship.Data.LogInfo
{
    [PetaPoco.TableName("loginfo")]
    [PetaPoco.PrimaryKey("UserID", autoIncrement = false)] 
    internal class LogInfoPoco
    {
        public DateTime TimeStamp { get; set; }
        public byte[] WebRequestID { get; set; }
        public byte[] UserID { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string Object { get; set; }
        public byte[] ID { get; set; }
    }
}
