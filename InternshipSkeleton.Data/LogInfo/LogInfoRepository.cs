using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignioInternship.Data.CombinedLogInfo;
using IntershipSkeleton.Demos.Data.Repositories;
using Utilities;

namespace AsignioInternship.Data.LogInfo
{
    public class LogInfoRepository : BaseRepository, ILogInfoRepository
    {
        public LogInfoRepository()
                : base(typeof(LogInfoRepository))
        { }

        public LogInfoDataModel GetFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.FirstOrDefault<LogInfoPoco>(LogInfoPoco.SelectByIDSQL, GuidMapper.Map(UserID)).ToModel();
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

        public IEnumerable<LogInfoDataModel> GetAll()
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogInfoPoco>(LogInfoPoco.SelectAll).Select(S => S.ToModel());
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

        public IEnumerable<LogInfoDataModel> GetAllFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogInfoPoco>(LogInfoPoco.SelectByIDSQL, GuidMapper.Map(UserID)).Select(S => S.ToModel());
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

        public PagedDataModelCollection<CombinedLogInfoDataModel> CombinedPageLogInfo(string nameSearchPattern,
                                       string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection)
        {
            using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
            {
                try
                {
                    PetaPoco.Sql sql = new PetaPoco.Sql();

                    sql.Append("SELECT ");
                    sql.Append("user.EmailAddress, loginfo.TimeStamp, loginfo.WebRequestID, loginfo.Message, loginfo.MethodName, loginfo.Object ");
                    sql.Append("from loginfo ");
                    sql.Append("INNER JOIN user on user.userID = loginfo.userID ");

                    if (!string.IsNullOrWhiteSpace(nameSearchPattern) && !string.IsNullOrWhiteSpace(searchColumn))
                    {
                        //format nameSearchPattern to be in '%_%' format 
                        if (nameSearchPattern[0] != '\'')
                        {
                            //nameSearchPattern = string.Format("\"{0}\"", nameSearchPattern);
                            nameSearchPattern = string.Format("\'%{0}%\'", nameSearchPattern);
                        }

                        if (/*searchColumn == "EmailAddress"*/ nameSearchPattern.Contains("@"))
                        {
                            string[] sections = nameSearchPattern.Split(new[] { '@' });
                            sections[1] = sections[1].Insert(0, "@@");
                            nameSearchPattern = string.Join("", sections);
                        }
                        //sql.Append(string.Format("WHERE {0}={1} ", searchColumn, nameSearchPattern));   

                        sql.Append(string.Format("WHERE {0} LIKE {1} ", searchColumn, nameSearchPattern));
                    }
                    sql.Append(string.Format("ORDER BY {0} {1}", sortColumn, sortDirection));

                    PetaPoco.Page<CombinedLogInfoPoco> page = db.Page<CombinedLogInfoPoco>(pageNumber, pageSize, sql);

                    if (page == null)
                    {
                        return null;
                    }

                    return new PagedDataModelCollection<CombinedLogInfoDataModel>()
                    {
                        Items = page.Items.Select(s => s.ToModel()),
                        PageNumber = pageNumber,
                        PageSize = pageSize,
                        TotalItems = page.TotalItems,
                        TotalPages = page.TotalPages,
                        SortBy = sortColumn,
                        SearchBy = searchColumn,
                        SearchInput = nameSearchPattern
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