Select user.EmailAddress, logexception.TimeStamp, logexception.MethodName, logexception.StackTrace, logexception.Source, logexception.Message, logexception.WebRequestID, logexception.Important
from logexception
inner join user on user.UserID = logexception.UserID
;