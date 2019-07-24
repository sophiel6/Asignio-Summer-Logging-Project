using System;

namespace AsignioInternship.Data.CombinedLogWebResponse
{
    public class CombinedLogWebResponseDataModel
    {
        public string EmailAddress { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid WebRequestID { get; set; }
        public string Status { get; set; }
        public string RedirectLocation { get; set; }
        public Guid UserID { get; set; }
        public string Important { get; set; }
    }
}

