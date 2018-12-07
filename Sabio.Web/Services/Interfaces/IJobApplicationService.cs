using System.Collections.Generic;
using System.Data;
using MediaForAll.Web.Domain;
using MediaForAll.Web.Models;

namespace MediaForAll.Web.Services
{
    public interface IJobApplicationService
    {
        int Insert(JobApplicationAddRequest model);

        List<JobApplication> GetAllJobApplications();

        JobApplication MapJobApplication(IDataReader reader, out int JobKey);

        JobApplication GetJobApplicationById(int id);

        void Delete(int ApplicationKey, int JobKey);


    }
}