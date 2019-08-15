using Utilities;

namespace AsignioInternship.Data.LogControllerAction
{
    internal static class CountryDataModelExtensions
    {
        internal static LogControllerActionDataModel ToModel(this LogControllerActionPoco source)
        {
            if (null != source)
            {
                return new LogControllerActionDataModel
                {
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    ControllerName = source.ControllerName,
                    ActionName = source.ActionName,
                    Parameters = source.Parameters,
                };
            }
            return null;
        }

        internal static LogControllerActionPoco ToPoco(this LogControllerActionDataModel source)
        {
            if (null != source)
            {
                return new LogControllerActionPoco
                {
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    UserID = GuidMapper.Map(source.UserID),
                    ControllerName = source.ControllerName,
                    ActionName = source.ActionName,
                    Parameters = source.Parameters,
                };
            }
            return null;
        }
    }
}