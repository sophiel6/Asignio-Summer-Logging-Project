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

        public PagedDataModelCollection<CombinedLogExceptionDataModel> CombinedPageLogException(int pageSize, int pageNum, string sortColumn, string sortDirection, Dictionary<string, string> searchDictionary)
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

                    bool FirstClause = true;
                    string dateString = "";

                    foreach (KeyValuePair<string, string> entry in searchDictionary) //format time ranges, important?
                    {
                        string userInput = entry.Value;

                        if (!string.IsNullOrWhiteSpace(userInput))
                        {  
                            if (entry.Key == "Important")
                            {
                                if (!FirstClause)
                                { sql.Append(string.Format("AND Important != \'\'")); }
                                else
                                { sql.Append(string.Format("WHERE Important != \'\'")); }
                                FirstClause = false;
                            }

                            else if (entry.Key == "TimeStamp") //format date
                            {
                                if (userInput[0] != '\'')
                                { userInput = string.Format("\'{0}\'", userInput); }
                                if (!FirstClause)
                                { sql.Append(string.Format("AND DATE(TimeStamp) = {0} ", userInput)); }
                                else
                                { sql.Append(string.Format("WHERE DATE(TimeStamp) = {0} ", userInput)); }
                                FirstClause = false;
                            }

                            else if (entry.Key == "beginDate") //format date range
                            {
                                if (userInput[0] != '\'') 
                                { userInput = string.Format("\'{0}\'", userInput); }
                                dateString = string.Format("DATE(TimeStamp) BETWEEN {0} AND ", userInput);
                            }
                            else if (entry.Key=="endDate" && dateString!="")
                            {
                                if (userInput[0] != '\'')
                                { userInput = string.Format("\'{0}\'", userInput); }

                                if (!FirstClause)
                                { sql.Append(string.Format("AND {0} {1} ", dateString, userInput)); }
                                else
                                { sql.Append(string.Format("WHERE {0} {1} ", dateString, userInput)); }
                                FirstClause = false;
                            }
                            else //if not a date
                            {
                                if (userInput.Contains("@")) //format email
                                {
                                    string[] sections = userInput.Split(new[] { '@' });
                                    sections[1] = sections[1].Insert(0, "@@");
                                    userInput = string.Join("", sections);
                                }
                                string newKey = entry.Key;
                                if (entry.Key == "UserImportant")
                                { newKey = "Important"; }

                                if (userInput[0] != '\'') 
                                {
                                    userInput = string.Format("\'%{0}%\'", userInput);
                                }
                                if (!FirstClause)
                                {
                                    sql.Append(string.Format("AND {0} LIKE {1} ", newKey, userInput));
                                }
                                else
                                {
                                    sql.Append(string.Format("WHERE {0} LIKE {1} ", newKey, userInput));
                                }
                                FirstClause = false;
                            }
                        }
                    }
                    sql.Append(string.Format("ORDER BY {0} {1}", sortColumn, sortDirection));

                    PetaPoco.Page<CombinedLogExceptionPoco> page = db.Page<CombinedLogExceptionPoco>(pageNum, pageSize, sql);

                    if (page == null)
                    {
                        return null;
                    }

                    return new PagedDataModelCollection<CombinedLogExceptionDataModel>()
                    {
                        Items = page.Items.Select(s => s.ToModel()),
                        PageNumber = pageNum,
                        PageSize = pageSize,
                        TotalItems = page.TotalItems,
                        TotalPages = page.TotalPages,
                        SortBy = sortColumn,
                        SortDirection = sortDirection,
                        SearchDictionary = searchDictionary,
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

        public int Update(CombinedLogExceptionDataModel LogToUpdate, string username)
         {
             try
             {
                 using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                 {
                     Byte[] bytes = new Byte[16];
                     Guid allZeros = new Guid(bytes);

                     Guid UserID = GetUserIDFromUsername(username);

                     if (UserID != allZeros)
                     {
                         if (username.Contains("@")) //format email
                         {
                             string[] sections = username.Split(new[] { '@' });
                             sections[1] = sections[1].Insert(0, "@@");
                             username = string.Join("", sections);
                         }

                         string sqlFormattedTimeStamp = LogToUpdate.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss");

                         PetaPoco.Sql sql = new PetaPoco.Sql();

                         username = string.Format("\"{0}\"", username);

                         sql.Append("SET SQL_SAFE_UPDATES = 0; ");
                         sql.Append(string.Format("UPDATE logexception SET Important = {0} ", username));
                         string where = string.Format("WHERE  TimeStamp = \"{0}\" AND WebRequestID = GuidToBinary(\"{1}\") AND UserID = GuidToBinary(\"{2}\") AND MethodName = \"{3}\" AND Source = \"{4}\"; ",
                             sqlFormattedTimeStamp, LogToUpdate.WebRequestID, LogToUpdate.UserID, LogToUpdate.MethodName, LogToUpdate.Source);
                         sql.Append(where);
                         sql.Append("SET SQL_SAFE_UPDATES = 1; ");

                         db.Execute(sql);
                         return 1;
                     }

                     else
                     { return 0; }
                 }
             }
             catch (Exception ex)
             {
                 string errorMessage = ex.Message;
             }
             finally
             { }
             return 0;
         } 

        public int UndoUpdate(CombinedLogExceptionDataModel LogToUpdate)
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    string sqlFormattedTimeStamp = LogToUpdate.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss");

                    PetaPoco.Sql sql = new PetaPoco.Sql();

                    string nullString = "null";

                    sql.Append("SET SQL_SAFE_UPDATES = 0; ");
                    sql.Append(string.Format("UPDATE logexception SET Important = {0} ", nullString));
                    string where = string.Format("WHERE  TimeStamp = \"{0}\" AND WebRequestID = GuidToBinary(\"{1}\") AND UserID = GuidToBinary(\"{2}\") AND MethodName = \"{3}\" AND Source = \"{4}\"; ",
                        sqlFormattedTimeStamp, LogToUpdate.WebRequestID, LogToUpdate.UserID, LogToUpdate.MethodName, LogToUpdate.Source);
                    sql.Append(where);
                    sql.Append("SET SQL_SAFE_UPDATES = 1; ");

                    db.Execute(sql);
                    return 1;
                }  
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                return 0;
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

                    sql.Append("SELECT UserID");
                    sql.Append("from user");

                    if (username.Contains("@")) //format email
                    {
                        string[] sections = username.Split(new[] { '@' });
                        sections[1] = sections[1].Insert(0, "@@");
                        username = string.Join("", sections);
                    }
                    username = string.Format("\"{0}\" ", username);
                    sql.Append(string.Format("WHERE EmailAddress = {0} ", username));
                    sql.Append(";");
                    CombinedLogExceptionPoco poco = db.FirstOrDefault<CombinedLogExceptionPoco>(sql);
                    CombinedLogExceptionDataModel model = poco.ToModel();

                    if (model != null)
                    {
                        return model.UserID;
                    }
                    else
                    {
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

            Byte[] bytes = new Byte[16];
            return new Guid(bytes);
        }

        // old Update() kept in just in case/for reference:
        /*
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
        */
    }
}   
