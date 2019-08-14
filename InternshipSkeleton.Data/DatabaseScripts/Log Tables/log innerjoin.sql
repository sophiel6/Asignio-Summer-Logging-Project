SELECT user.EmailAddress, log.UserID, log.TimeStamp, log.LogID, log.Level, log.Message, log.Source, log.Important
from log
INNER JOIN user on user.userID = log.userID
;