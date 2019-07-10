using Utilities;

namespace AsignioInternship.Data.CombinedLogControllerAction
{
    internal static class CountryDataModelExtensions
    {
        internal static CombinedLogControllerActionDataModel ToModel(this CombinedLogControllerActionPoco source)
        {
            if (null != source)
            {

                return new CombinedLogControllerActionDataModel
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    ControllerName = source.ControllerName,
                    ActionName = source.ActionName,
                    Parameters = source.Parameters,
                };
            }

            return null;
        }

        internal static CombinedLogControllerActionPoco ToPoco(this CombinedLogControllerActionDataModel source)
        {
            if (null != source)
            {
                return new CombinedLogControllerActionPoco
                {
                    EmailAddress = source.EmailAddress,
                    TimeStamp = source.TimeStamp,
                    WebRequestID = GuidMapper.Map(source.WebRequestID),
                    ControllerName = source.ControllerName,
                    ActionName = source.ActionName,
                    Parameters = source.Parameters,
                };
            }

            return null;
        }
    }
}
