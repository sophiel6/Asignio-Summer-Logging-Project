SELECT TimeStamp, WebRequestID, ControllerName, ActionName, Parameters, Important
from logcontrolleraction
inner join user on user.UserID = logcontrolleraction.UserID;