using Utilities;

namespace AsignioInternship.Data.User
{
    internal static class CountryDataModelExtensions
    {
        internal static UserDataModel ToModel(this UserPoco source)
        {
            if (null != source)
            {
                return new UserDataModel
                {
                    EmailAddress = source.EmailAddress,
                    UserID = GuidMapper.Map(source.UserID),
                };
            }

            return null;
        }

        internal static UserPoco ToPoco(this UserDataModel source)
        {
            if (null != source)
            {
                return new UserPoco
                {
                    EmailAddress = source.EmailAddress,
                    UserID = GuidMapper.Map(source.UserID),
                };
            }

            return null;
        }
    }
}
