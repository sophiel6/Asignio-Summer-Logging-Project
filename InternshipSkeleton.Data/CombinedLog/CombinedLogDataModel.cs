using System;

namespace AsignioInternship.Data.CombinedLog
{
    public class CombinedLogDataModel
    {
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid LogID { get; set; }
        public int Level { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Important { get; set; }
        public Guid UserID { get; set; }
    }
}

