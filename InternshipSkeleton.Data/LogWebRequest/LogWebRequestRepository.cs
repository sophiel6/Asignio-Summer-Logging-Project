using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntershipSkeleton.Demos.Data.Repositories;
using Utilities;

namespace AsignioInternship.Data.LogWebRequest
{
    public class LogWebRequestRepository : BaseRepository, ILogWebRequestRepository
    {
        public LogWebRequestRepository()
                : base(typeof(LogWebRequestRepository))
        { }

        public LogWebRequestDataModel GetFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.FirstOrDefault<LogWebRequestPoco>(LogWebRequestPoco.SelectByIDSQL, GuidMapper.Map(UserID)).ToModel();
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

        public IEnumerable<LogWebRequestDataModel> GetAll()
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogWebRequestPoco>(LogWebRequestPoco.SelectAll).Select(S => S.ToModel());
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

        public IEnumerable<LogWebRequestDataModel> GetAllFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogWebRequestPoco>(LogWebRequestPoco.SelectByIDSQL, GuidMapper.Map(UserID)).Select(S => S.ToModel());
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

        public PagedDataModelCollection<LogWebRequestDataModel> PageLogWebRequest(string nameSearchPattern, int pageSize, int pageNumber, string sortColumn, string sortDirection)
        {
            using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
            {
                try
                {
                    PetaPoco.Sql sql = new PetaPoco.Sql();

                    sql.Append(LogWebRequestPoco.BaseSQL);

                    if (!string.IsNullOrWhiteSpace(nameSearchPattern))
                    {
                        nameSearchPattern = string.Format("{0}", nameSearchPattern);

                        //sql.Append(LogWebRequestPoco.PageUsersByUserIDSearchSQL, nameSearchPattern);
                    }

                    sql.Append(string.Format("ORDER BY {0} {1}", sortColumn, sortDirection));

                    PetaPoco.Page<LogWebRequestPoco> page = db.Page<LogWebRequestPoco>(pageNumber, pageSize, sql);

                    if (page == null)
                    {
                        return null;
                    }

                    return new PagedDataModelCollection<LogWebRequestDataModel>()
                    {
                        Items = page.Items.Select(s => s.ToModel()),
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalItems = page.TotalItems,
                        TotalPages = page.TotalPages,
                        SortBy = sortColumn
                    };
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;
                }
                finally
                {
                }
            }

            return null;
        }
    }
}
 