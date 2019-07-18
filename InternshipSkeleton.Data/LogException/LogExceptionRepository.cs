﻿using System;
using System.Collections.Generic;
using System.Linq;
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
                    sql.Append("user.EmailAddress, logexception.UserID, logexception.TimeStamp, logexception.WebRequestID, logexception.Message, " +
                               "logexception.MethodName, logexception.Source, logexception.StackTrace, logexception.Important ");
                    sql.Append(" from logexception ");
                    sql.Append(" INNER JOIN user on user.userID = logexception.userID ");
                    
                    if (!string.IsNullOrWhiteSpace(nameSearchPattern) && !string.IsNullOrWhiteSpace(searchColumn))
                    {

                        if (nameSearchPattern.Contains("@")) //format email
                        {
                            string[] sections = nameSearchPattern.Split(new[] { '@' });
                            sections[1] = sections[1].Insert(0, "@@");
                            nameSearchPattern = string.Join("", sections);
                        }
                        if (searchColumn == "TimeStamp") //format date 
                        {
                            if (nameSearchPattern[0] != '\'') //format all search strings
                            {
                                nameSearchPattern = string.Format("\'{0}\'", nameSearchPattern);
                            }
                            sql.Append(string.Format("WHERE DATE({0}) = {1} ", searchColumn, nameSearchPattern));
                        }
                        else //if not a date
                        {
                            if (nameSearchPattern[0] != '\'') //format non-date searches
                            {
                                nameSearchPattern = string.Format("\'%{0}%\'", nameSearchPattern);
                            }
                            sql.Append(string.Format("WHERE {0} LIKE {1} ", searchColumn, nameSearchPattern));
                        }
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


        public void Update(CombinedLogExceptionDataModel LogToUpdate, Guid UserID)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    Byte[] bytes = new Byte[16];
                    Guid allZeros = new Guid(bytes);

                    if (UserID != allZeros)
                    {
                        CombinedLogExceptionPoco poco = LogToUpdate.ToPoco();
                        db.Update(poco); //I think for some reason the UserID of the poco doesn't match the userID in the sql database?
                    }
                    else
                    {
                        //what happens if the username entered doesn't match a userID? 
                    }

                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }
            finally
            { }
        }

        public Guid GetUserIDFromUsername(string username)
        {   /* This function will search the user db for this username/Email - if it is found, it'll 
             * return the corresponding UserID; if not, it'll return some default Guid */
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    PetaPoco.Sql sql = new PetaPoco.Sql();

                    //is this query doing the right search? maybe just need to search for the username in "user" table
                    //and return its associated UserID? 

                    /*sql.Append("SELECT user.EmailAddress, logexception.* ");
                    sql.Append("from logexception ");
                    sql.Append("INNER JOIN user on user.UserID = logexception.UserID "); */

                    sql.Append("Select user.UserID, user.EmailAddress ");
                    sql.Append("FROM user ");
                    

                    if (username.Contains("@")) //format email
                    {
                        string[] sections = username.Split(new[] { '@' });
                        sections[1] = sections[1].Insert(0, "@@");
                        username = string.Join("", sections);
                    }
                    username = string.Format("\"{0}\" ", username);
                    sql.Append(string.Format("WHERE user.EmailAddress = {0} ", username));
                    //CombinedLogExceptionPoco poco = db.FirstOrDefault<CombinedLogExceptionPoco>(sql);
                    //CombinedLogExceptionDataModel model = poco.ToModel();
                    UserPoco poco = db.FirstOrDefault<UserPoco>(sql);
                    UserDataModel model = poco.ToModel();

                    if (model != null)
                    {
                        return model.UserID;
                    }
                    else
                    {
                        //not sure - for now returning a guid of all zeros
                        Byte[] allZeroByte = new Byte[16];
                        return new Guid(allZeroByte);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
            }
            finally
            { }

            //returning an all-0 guid
            Byte[] bytes = new Byte[16];
            return new Guid(bytes);
        }
    }   
}