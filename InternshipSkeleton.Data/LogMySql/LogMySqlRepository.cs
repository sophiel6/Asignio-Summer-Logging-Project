using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntershipSkeleton.Demos.Data.Repositories;
using Utilities;

namespace AsignioInternship.Data.LogMySql
{
    public class LogMySqlRepository : BaseRepository, ILogMySqlRepository
    {
        public LogMySqlRepository()
                : base(typeof(LogMySqlRepository))
        { }


            /*
        public LogMySqlDataModel GetFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.FirstOrDefault<LogMySqlPoco>(LogMySqlPoco.SelectByIDSQL, GuidMapper.Map(UserID)).ToModel();
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
        */
        public IEnumerable<LogMySqlDataModel> GetAll()
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogMySqlPoco>(LogMySqlPoco.SelectAll).Select(S => S.ToModel());
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
        public PagedDataModelCollection<LogMySqlDataModel> PageLogMySql(string nameSearchPattern, int pageSize, int pageNumber, string sortColumn, string sortDirection)
        {
            using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
            {
                try
                {
                    PetaPoco.Sql sql = new PetaPoco.Sql();

                    sql.Append(LogMySqlPoco.BaseSQL);

                    if (!string.IsNullOrWhiteSpace(nameSearchPattern))
                    {
                        nameSearchPattern = string.Format("{0}", nameSearchPattern);

                        //sql.Append(LogWebRequestPoco.PageUsersByUserIDSearchSQL, nameSearchPattern);
                    }

                    sql.Append(string.Format("ORDER BY {0} {1}", sortColumn, sortDirection));

                    PetaPoco.Page<LogMySqlPoco> page = db.Page<LogMySqlPoco>(pageNumber, pageSize, sql);

                    if (page == null)
                    {
                        return null;
                    }

                    return new PagedDataModelCollection<LogMySqlDataModel>()
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