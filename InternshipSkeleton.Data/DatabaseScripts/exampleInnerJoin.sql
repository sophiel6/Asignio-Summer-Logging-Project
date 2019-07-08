use internshipschema;
SELECT user.EmailAddress, logexception.TimeStamp, logexception.Message, logexception.MethodName, logexception.Source, logexception.StackTrace
FROM (logexception
INNER JOIN user ON user.userID = logexception.userID);