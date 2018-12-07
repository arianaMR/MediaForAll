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
    public class JobApplicationService : BaseService, IJobApplicationService
    {
        public int Insert(JobApplicationAddRequest model)
        {
            int JobApplicantKey = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Applicant_Job_Insert", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@ApplicantKey", model.ApplicantKey);
                paramCollection.AddWithValue("@JobKey", model.JobKey);
                SqlParameter p = new SqlParameter("@JobApplicantKey", System.Data.SqlDbType.Int);
                p.Direction = System.Data.ParameterDirection.Output;
                paramCollection.Add(p);
            }, returnParameters: delegate (SqlParameterCollection param)
            {
                int.TryParse(param["@JobApplicantKey"].Value.ToString(), out JobApplicantKey);
            }
               );
           
            return JobApplicantKey;
        }

        public List<JobApplication> GetAllJobApplications()
        {
            List<JobApplication> jobList = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Applicant_Job_GetAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    int transactionId = 0;
                    JobApplication jobApplication = MapJobApplication(reader, out transactionId);

                    if (jobList == null)
                    {
                        jobList = new List<JobApplication>();
                    }

                    jobList.Add(jobApplication);
                }
                );
            return jobList;
        }


        public JobApplication GetJobApplicationById(int id)
        {
            JobApplication jobApplication = new JobApplication();
            int TransactionId = 0;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Applicant_Job_Get"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@ApplicantKey", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    jobApplication = MapJobApplication(reader, out TransactionId);
                }
                );
            return jobApplication;
        }

        public JobApplication MapJobApplication(IDataReader reader, out int JobKey)
        {
            JobApplication d = new JobApplication();
            int index = 0;
            d.ApplicantKey = reader.GetSafeInt32(index++);
            d.FirstName = reader.GetSafeString(index++);
            d.LastName = reader.GetSafeString(index++);
            d.Phone = reader.GetSafeString(index++);
            d.Email = reader.GetSafeString(index++);
            d.JoinDate = reader.GetDateTime(index++);
            d.JobKey = reader.GetSafeInt32(index++);
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


        public void Delete(int ApplicantKey, int JobKey)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Applicant_Job_Delete", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@ApplicantKey", ApplicantKey);
                paramCollection.AddWithValue("@JobKey", JobKey);
            }, returnParameters: null
            );
        }


    }
}