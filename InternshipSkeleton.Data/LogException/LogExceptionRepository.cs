using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignioInternship.Data.CombinedLogException;
using AsignioInternship.Data.User;
using IntershipSkeleton.Demos.Data.Repositories;
using Utilities;

namespace AsignioInternship.Data.LogException
{
    public class LogExceptionRepository : BaseRepository, ILogExceptionRepository
    {
        public LogExceptionRepository()
                : base(typeof(LogExceptionRepository))
        { }

        public LogExceptionDataModel GetFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.FirstOrDefault<LogExceptionPoco>(LogExceptionPoco.SelectByIDSQL, GuidMapper.Map(UserID)).ToModel();
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

        public IEnumerable<LogExceptionDataModel> GetAll()
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogExceptionPoco>(LogExceptionPoco.SelectAll).Select(S => S.ToModel());
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

        public IEnumerable<LogExceptionDataModel> GetAllFromUserID(Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    return db.Fetch<LogExceptionPoco>(LogExceptionPoco.SelectByIDSQL, GuidMapper.Map(UserID)).Select(S => S.ToModel());
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

        /*public PagedDataModelCollection<LogExceptionDataModel> PageLogException(string nameSearchPattern, int pageSize, int pageNumber, string sortColumn, string sortDirection)
        {
            using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
            {
                try
                {
                    PetaPoco.Sql sql = new PetaPoco.Sql();

                    sql.Append(LogExceptionPoco.BaseSQL);

                    if (!string.IsNullOrWhiteSpace(nameSearchPattern))
                    {
                        nameSearchPattern = string.Format("{0}", nameSearchPattern);

                        sql.Append(LogExceptionPoco.PageUsersByUserIDSearchSQL, nameSearchPattern);
                    }

                    sql.Append(string.Format("ORDER BY {0} {1}", sortColumn, sortDirection));

                    PetaPoco.Page<LogExceptionPoco> page = db.Page<LogExceptionPoco>(pageNumber, pageSize, sql);

                    if (page == null)
                    {
                        return null;
                    }

                    return new PagedDataModelCollection<LogExceptionDataModel>()
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

        public IEnumerable<CombinedLogExceptionDataModel> ExampleQuery()
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    IEnumerable<LogExceptionDataModel> LogExceptionList = db.Fetch<LogExceptionPoco>(LogExceptionPoco.SelectAll).Select(S => S.ToModel());
                    IEnumerable<UserDataModel> UsersList = db.Fetch<UserPoco>(UserPoco.SelectAll).Select(S => S.ToModel());
                    IEnumerable<CombinedLogExceptionDataModel> CombinedLogExceptionList =
                            LogExceptionList.Join(UsersList, user => user.UserID,
                            logexception => logexception.UserID,
                            (logexception, user) => new CombinedLogExceptionDataModel
                            {
                                EmailAddress = user.EmailAddress,
                                TimeStamp = logexception.TimeStamp,
                                WebRequestID = logexception.WebRequestID,
                                Message = logexception.Message,
                                MethodName = logexception.MethodName,
                                Source = logexception.Source,
                                StackTrace = logexception.StackTrace,
                            });
                    return (CombinedLogExceptionList);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }
            return null;
        }
        */

        public PagedDataModelCollection<CombinedLogExceptionDataModel> CombinedPageLogException(string nameSearchPattern, 
                                string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection)
        {
            using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
            {
                try
                {
                    PetaPoco.Sql sql = new PetaPoco.Sql();

                    sql.Append("SELECT ");
                    sql.Append("user.EmailAddress, logexception.TimeStamp, logexception.WebRequestID, logexception.Message, logexception.MethodName, logexception.Source, logexception.StackTrace");
                    sql.Append(" from logexception ");
                    sql.Append(" INNER JOIN user on user.userID = logexception.userID ");
                    
                    if (!string.IsNullOrWhiteSpace(nameSearchPattern) && !string.IsNullOrWhiteSpace(searchColumn))
                    {
                        //I think if the search pattern is a TimeStamp, it needs to be converted to DateTime
                        //however, TimeStamp works if you search it in the format that it's in in the Sql table 

                        nameSearchPattern = string.Format("\"{0}\"", nameSearchPattern);

                        if (searchColumn == "EmailAddress")
                        {
                            string[] sections = nameSearchPattern.Split(new[] { '@' });
                            sections[1] = sections[1].Insert(0, "@@");
                            nameSearchPattern = string.Join("", sections);
                        }

                        sql.Append(string.Format("WHERE {0}={1} ", searchColumn, nameSearchPattern));
                        //sql.Append(LogExceptionPoco.PageUsersByMethodNameSearchSQL, nameSearchPattern);
                    }
                    
                    sql.Append(string.Format("ORDER BY {0} {1}", sortColumn, sortDirection));

                    PetaPoco.Page<CombinedLogExceptionPoco> page = db.Page<CombinedLogExceptionPoco>(pageNumber, pageSize, sql);

                    if (page == null)
                    {
                        return null;
                    }

                    return new PagedDataModelCollection<CombinedLogExceptionDataModel>()
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


