select user.EmailAddress, logwebresponse.TimeStamp, logwebresponse.WebRequestID, logwebresponse.Status, logwebresponse.Important
from logwebresponse
inner join user on user.UserID = logwebresponse.UserID
;