using MediaForAll.Data;
using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MediaForAll.Web.Services
{
    public class JobService : BaseService, IJobService
    {
        public int Insert(JobAddRequest model)
        {
            int JobKey = 0;
            int CategoryKey = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Job_Insert", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@CategoryKey", CategoryKey);
                paramCollection.AddWithValue("@CategoryName", model.CategoryName);
                paramCollection.AddWithValue("@ProductionName", model.ProductionName);
                paramCollection.AddWithValue("@JobDescription", model.JobDescription);
                paramCollection.AddWithValue("@ProductionDate", model.ProductionDate);
                paramCollection.AddWithValue("@CallTime", model.CallTime);
                paramCollection.AddWithValue("@TimeCommitment", model.TimeCommitment);
                paramCollection.AddWithValue("@Notes", model.Notes);
                SqlParameter p = new SqlParameter("@JobKey", System.Data.SqlDbType.Int);
                p.Direction = System.Data.ParameterDirection.Output;
                paramCollection.Add(p);
            }, returnParameters: delegate (SqlParameterCollection param)
            {
                int.TryParse(param["@JobKey"].Value.ToString(), out JobKey);
            }
               );
           
            return JobKey;
        }

        public List<Job> GetAllJobs()
        {
            List<Job> jobList = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Job_GetAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    int transactionId = 0;
                    Job job = MapJob(reader, out transactionId);

                    if (jobList == null)
                    {
                        jobList = new List<Job>();
                    }

                    jobList.Add(job);
                }
                );
            return jobList;
        }


        public Job MapJob(IDataReader reader, out int JobKey)
        {
            Job d = new Job();
            int index = 0;
            d.JobKey = reader.GetSafeInt32(index++);
            d.CategoryKey = reader.GetSafeInt32(index++);
            d.CategoryName = reader.GetSafeString(index++);
            d.ProductionName = reader.GetSafeString(index++);
            d.JobDescription = reader.GetSafeString(index++);
            d.ProductionDate = reader.GetDateTime(index++);
            d.CallTime = reader.GetSafeString(index++);
            d.TimeCommitment = reader.GetSafeString(index++);
            d.Notes = reader.GetSafeString(index++);

            JobKey = d.JobKey;

            return d;
        }


        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Job_Delete", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@JobKey", id);
            }, returnParameters: null
            );
        }


    }
}