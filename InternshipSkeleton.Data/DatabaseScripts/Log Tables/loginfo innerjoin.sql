SELECT user.EmailAddress, loginfo.TimeStamp, loginfo.WebRequestID, loginfo.MethodName, loginfo.Message, loginfo.Object, loginfo.Important
from loginfo
inner join user on user.UserID = loginfo.UserID;