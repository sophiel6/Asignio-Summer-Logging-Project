﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntershipSkeleton.Demos.Data.Repositories;
using Utilities;

namespace AsignioInternship.Data.LogInfo
{
    public class LogInfoRepository : BaseRepository, ILogInfoRepository
    {
        public LogInfoRepository()
                : base(typeof(LogInfoRepository))
        { }

        //public ExampleRepository(string connectionStringName)
        //	: base(typeof(ExampleRepository), connectionStringName)
        //{ }

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
        /*
        public ExampleDataModel Insert(ExampleDataModel dataModel) // always do insert and update together. Check if it already exists, if so update, if not insert
        {
            try
            {
                using (AsignioDatabase db = new AsignioDatabase(ConnectionStringName))
                {
                    ExampleDataModel returnModel = GetFromID(dataModel.ExampleID);
                    ExamplePoco poco = dataModel.ToPoco();
                    if (returnModel != null)
                    {
                        db.Update(poco);
                    }
                    else
                    {
                        poco.ExampleID = GuidMapper.Map(Guid.NewGuid());
                        poco.DateAdded = DateTime.Now;
                        db.Insert(poco);
                    }
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
    }
}