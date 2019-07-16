﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignioInternship.Data.CombinedLogControllerAction;
using IntershipSkeleton.Demos.Data.Repositories;
using Utilities;

namespace AsignioInternship.Data.LogControllerAction
{
    public class LogControllerActionRepository : BaseRepository, ILogControllerActionRepository
    {
        public LogControllerActionRepository()
                : base(typeof(LogControllerActionRepository))
        { }

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

        public PagedDataModelCollection<CombinedLogControllerActionDataModel> CombinedPageLogControllerAction(string nameSearchPattern,
                                        string searchColumn, int pageSize, int pageNumber, string sortColumn, string sortDirection)
        {
            using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
            {
                try
                {
                    PetaPoco.Sql sql = new PetaPoco.Sql();

                    sql.Append("SELECT ");
                    sql.Append("user.EmailAddress, logcontrolleraction.Timestamp, logcontrolleraction.WebRequestID, logcontrolleraction.ControllerName, logcontrolleraction.ActionName, logcontrolleraction.Parameters ");
                    sql.Append("from logcontrolleraction ");
                    sql.Append("INNER JOIN user on user.userID = logcontrolleraction.userID ");

                    if (!string.IsNullOrWhiteSpace(nameSearchPattern) && !string.IsNullOrWhiteSpace(searchColumn))
                    {
                        //format nameSearchPattern to be in '%_%' format 
                        if (nameSearchPattern[0] != '\'')
                        {
                            //nameSearchPattern = string.Format("\"{0}\"", nameSearchPattern);
                            nameSearchPattern = string.Format("\'%{0}%\'", nameSearchPattern);
                        }

                        if (nameSearchPattern.Contains("@")) //if search pattern is an email
                        {
                            string[] sections = nameSearchPattern.Split(new[] { '@' });
                            sections[1] = sections[1].Insert(0, "@@");
                            nameSearchPattern = string.Join("", sections);
                        }
                        //sql.Append(string.Format("WHERE {0}={1} ", searchColumn, nameSearchPattern));   
                        sql.Append(string.Format("WHERE {0} LIKE {1} ", searchColumn, nameSearchPattern));
                    }
                    sql.Append(string.Format("ORDER BY {0} {1}", sortColumn, sortDirection));

                    PetaPoco.Page<CombinedLogControllerActionPoco> page = db.Page<CombinedLogControllerActionPoco>(pageNumber, pageSize, sql);

                    if (page == null)
                    {
                        return null;
                    }

                    return new PagedDataModelCollection<CombinedLogControllerActionDataModel>()
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