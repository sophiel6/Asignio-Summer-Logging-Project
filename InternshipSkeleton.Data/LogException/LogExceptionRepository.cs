using System;
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

                    bool FirstClause = true;    //a boolean to keep track of whether sql string is at first search clause
                    string dateString = "";

                    foreach (KeyValuePair<string, string> entry in searchDictionary)
                    {
                        string userInput = entry.Value;

                        if (!string.IsNullOrWhiteSpace(userInput))
                        {
                            if (entry.Key == "Important") //only get logs that are marked as important
                            {
                                if (!FirstClause)
                                { sql.Append(string.Format("AND Important != \'\'")); }
                                else
                                { sql.Append(string.Format("WHERE Important != \'\'")); }
                                FirstClause = false;
                            }
                            else if (entry.Key == "TimeStamp") //get logs from one specific date
                            {
                                if (userInput[0] != '\'')
                                { userInput = string.Format("\'{0}\'", userInput); }
                                if (!FirstClause)
                                { sql.Append(string.Format("AND DATE(TimeStamp) = {0} ", userInput)); }
                                else
                                { sql.Append(string.Format("WHERE DATE(TimeStamp) = {0} ", userInput)); }
                                FirstClause = false;
                            }

                            else if (entry.Key == "beginDate") //format beginning of date range
                            {
                                if (userInput[0] != '\'')
                                { userInput = string.Format("\'{0}\'", userInput); }
                                dateString = string.Format("DATE(TimeStamp) BETWEEN {0} AND ", userInput);
                            }
                            else if (entry.Key == "endDate" && dateString != "") //format end of date range
                            {
                                if (userInput[0] != '\'')
                                { userInput = string.Format("\'{0}\'", userInput); }

                                if (!FirstClause)
                                { sql.Append(string.Format("AND {0} {1} ", dateString, userInput)); }
                                else
                                { sql.Append(string.Format("WHERE {0} {1} ", dateString, userInput)); }
                                FirstClause = false;
                            }
                            else 
                            {
                                if (userInput.Contains("@")) //format email
                                {
                                    string[] sections = userInput.Split(new[] { '@' });
                                    sections[1] = sections[1].Insert(0, "@@");
                                    userInput = string.Join("", sections);
                                }
                                string newKey = entry.Key; //formatting for "get logs marked as important by a specific username"
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
                finally { }
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
        {   
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
    }
}   
