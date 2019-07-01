using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntershipSkeleton.Demos.Data.Repositories;
using Utilities;

namespace AsignioInternship.Data.LogControllerAction
{
    public class LogControllerActionRepository : BaseRepository, ILogControllerActionRepository
    {
        public LogControllerActionRepository()
                : base(typeof(LogControllerActionRepository))
        { }

        //public ExampleRepository(string connectionStringName)
        //	: base(typeof(ExampleRepository), connectionStringName)
        //{ }

        public LogControllerActionDataModel GetFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.FirstOrDefault<LogControllerActionPoco>(LogControllerActionPoco.SelectByIDSQL, GuidMapper.Map(UserID)).ToModel();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }
            finally
            { }

            return null;
        }

        //Adding - get all from user ID method
        public IEnumerable<LogControllerActionDataModel> GetAllFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogControllerActionPoco>(LogControllerActionPoco.SelectByIDSQL, GuidMapper.Map(UserID)).Select(S => S.ToModel());
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }
            finally
            { }

            return null;
        }

        public IEnumerable<LogControllerActionDataModel> GetAll()
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogControllerActionPoco>(LogControllerActionPoco.SelectAll).Select(S => S.ToModel());
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }
            finally
            { }

            return null;
        }

    }
}